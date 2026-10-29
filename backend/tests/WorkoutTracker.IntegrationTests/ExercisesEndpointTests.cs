using System.Net.Http.Json;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using WorkoutTracker.Application.Services.Exercises.DTOs;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.IntegrationTests;

public sealed class ExercisesEndpointTests(WorkoutTrackerApiFixture fixture) : IClassFixture<WorkoutTrackerApiFixture>
{
    [Fact]
    public async Task GetExercises_ReturnsActiveExercisesOrderedWithMuscleGroups()
    {
        await using var scope = fixture.Factory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<WorkoutTrackerDbContext>();

        var testRunId = Guid.NewGuid().ToString("N");
        var benchPressName = $"test-{testRunId}-bench-press";
        var squatName = $"test-{testRunId}-squat";
        var deletedName = $"test-{testRunId}-deleted";
        var chestName = $"a-{testRunId}-chest";
        var tricepsName = $"z-{testRunId}-triceps";

        var benchPress = CreateExercise(benchPressName);
        benchPress.MuscleGroups.Add(CreateExerciseMuscleGroup(benchPress, chestName, "Primary"));
        benchPress.MuscleGroups.Add(CreateExerciseMuscleGroup(benchPress, tricepsName, "Secondary"));

        var exerciseIds = new[] { Guid.NewGuid(), benchPress.Id, Guid.NewGuid() };

        try
        {
            context.Exercises.AddRange(
                CreateExercise(squatName, exerciseIds[0]),
                benchPress,
                CreateExercise(deletedName, exerciseIds[2], isDeleted: true));
            await context.SaveChangesAsync();

            using var response = await fixture.Client.GetAsync("/api/exercises");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var exercises = await response.Content.ReadFromJsonAsync<ExerciseResponse[]>();
            Assert.NotNull(exercises);

            var testExercises = exercises
                .Where(exercise => exercise.Name.StartsWith($"test-{testRunId}-", StringComparison.Ordinal))
                .ToArray();

            Assert.Collection(
                testExercises,
                exercise => Assert.Equal(benchPressName, exercise.Name),
                exercise => Assert.Equal(squatName, exercise.Name));

            Assert.Collection(
                testExercises[0].MuscleGroups,
                muscleGroup =>
                {
                    Assert.Equal(chestName, muscleGroup.Name);
                    Assert.Equal("Primary", muscleGroup.Role);
                },
                muscleGroup =>
                {
                    Assert.Equal(tricepsName, muscleGroup.Name);
                    Assert.Equal("Secondary", muscleGroup.Role);
                });
        }
        finally
        {
            var createdExercises = await context.Exercises.IgnoreQueryFilters().Where(exercise => exerciseIds.Contains(exercise.Id)).ToListAsync();
            context.Exercises.RemoveRange(createdExercises);
            await context.SaveChangesAsync();

            var muscleGroups = await context.MuscleGroups
                .Where(muscleGroup => muscleGroup.Name == chestName || muscleGroup.Name == tricepsName)
                .ToListAsync();
            context.MuscleGroups.RemoveRange(muscleGroups);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task GetById_ReturnsCorrectExerciseWithMuscleGroups()
    {
        await using var scope = fixture.Factory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<WorkoutTrackerDbContext>();

        var testRunId = Guid.NewGuid().ToString("N");
        var benchPressName = $"test-{testRunId}-bench-press";
        var chestName = $"a-{testRunId}-chest";
        var tricepsName = $"z-{testRunId}-triceps";
        var exGuid = Guid.NewGuid();

        var benchPress = CreateExercise(benchPressName, id: exGuid);
        benchPress.MuscleGroups.Add(CreateExerciseMuscleGroup(benchPress, chestName, "Primary"));
        benchPress.MuscleGroups.Add(CreateExerciseMuscleGroup(benchPress, tricepsName, "Secondary"));

        try
        {
            context.Exercises.Add(benchPress);
            await context.SaveChangesAsync();

            using var response = await fixture.Client.GetAsync($"/api/exercises/{exGuid}");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var exercise = await response.Content.ReadFromJsonAsync<ExerciseResponse>();
            Assert.NotNull(exercise);
            Assert.Equal(exGuid, exercise.Id);
            Assert.Equal(benchPressName, exercise.Name);

            Assert.Collection(
                exercise.MuscleGroups,
                muscleGroup =>
                {
                    Assert.Equal(chestName, muscleGroup.Name);
                    Assert.Equal("Primary", muscleGroup.Role);
                },
                muscleGroup =>
                {
                    Assert.Equal(tricepsName, muscleGroup.Name);
                    Assert.Equal("Secondary", muscleGroup.Role);
                });
        }
        finally
        {
            var createdExercises = await context.Exercises
                .IgnoreQueryFilters()
                .Where(exercise => exercise.Id == benchPress.Id)
                .ToListAsync();
            context.Exercises.RemoveRange(createdExercises);
            await context.SaveChangesAsync();

            var muscleGroups = await context.MuscleGroups
                .Where(muscleGroup => muscleGroup.Name == chestName || muscleGroup.Name == tricepsName)
                .ToListAsync();
            context.MuscleGroups.RemoveRange(muscleGroups);
            await context.SaveChangesAsync();
        }
    }

    [Fact]
    public async Task GetById_ReturnsNotFoundForUnknownExercise()
    {
        using var response = await fixture.Client.GetAsync($"/api/exercises/{Guid.NewGuid()}");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateExercise_ReturnsCreatedExerciseAndPersistsIt()
    {
        await using var scope = fixture.Factory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<WorkoutTrackerDbContext>();

        var exerciseName = $"test-{Guid.NewGuid():N}-create";
        var muscleGroup = new MuscleGroup { Name = $"test-{Guid.NewGuid():N}-muscle-group" };
        context.MuscleGroups.Add(muscleGroup);
        await context.SaveChangesAsync();

        var request = new CreateExerciseRequest(
            Name: exerciseName,
            Description: "Integration test exercise",
            EquipmentType: EquipmentType.Dumbbell,
            MediaUrl: "https://example.test/exercises/test-create.jpg",
            TrackingMode: TrackingMode.RepsAndWeight,
            MuscleGroups: [new CreateExerciseMuscleGroupRequest(muscleGroup.Id, "Primary")],
            CreatedByUserId: null);
        Guid? createdExerciseId = null;

        try
        {
            using var response = await fixture.Client.PostAsJsonAsync("/api/exercises", request);

            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
            var createdExercise = await response.Content.ReadFromJsonAsync<ExerciseResponse>();
            Assert.NotNull(createdExercise);

            createdExerciseId = createdExercise.Id;
            AssertResponseMatchesRequest(createdExercise, request, muscleGroup.Name);

            var persistedExercise = await context.Exercises
                .IgnoreQueryFilters()
                .SingleAsync(exercise => exercise.Id == createdExercise.Id);

            AssertEntityMatchesRequest(persistedExercise, request);
            Assert.False(persistedExercise.IsDeleted);

            var persistedMuscleGroup = await context.ExerciseMuscleGroups
                .Include(exerciseMuscleGroup => exerciseMuscleGroup.MuscleGroup)
                .SingleAsync(exerciseMuscleGroup => exerciseMuscleGroup.ExerciseId == createdExercise.Id);

            Assert.Equal(muscleGroup.Id, persistedMuscleGroup.MuscleGroupId);
            Assert.Equal(muscleGroup.Name, persistedMuscleGroup.MuscleGroup.Name);
            Assert.Equal("Primary", persistedMuscleGroup.Role);
        }
        finally
        {
            if (createdExerciseId is Guid exerciseId)
            {
                var createdMuscleGroups = await context.ExerciseMuscleGroups
                    .Where(exerciseMuscleGroup => exerciseMuscleGroup.ExerciseId == exerciseId)
                    .ToListAsync();
                context.ExerciseMuscleGroups.RemoveRange(createdMuscleGroups);

                var createdExercise = await context.Exercises
                    .IgnoreQueryFilters()
                    .SingleOrDefaultAsync(exercise => exercise.Id == exerciseId);

                if (createdExercise is not null)
                {
                    context.Exercises.Remove(createdExercise);
                }

                await context.SaveChangesAsync();
            }

            context.MuscleGroups.Remove(muscleGroup);
            await context.SaveChangesAsync();
        }
    }

    private static void AssertResponseMatchesRequest(
        ExerciseResponse response,
        CreateExerciseRequest request,
        string muscleGroupName)
    {
        Assert.Equal(request.Name, response.Name);
        Assert.Equal(request.Description, response.Description);
        Assert.Equal(request.EquipmentType, response.EquipmentType);
        Assert.Equal(request.MediaUrl, response.MediaUrl);
        Assert.Equal(request.TrackingMode, response.TrackingMode);
        Assert.False(response.IsBuiltIn);
        var group = Assert.Single(response.MuscleGroups);
        Assert.Equal(request.MuscleGroups[0].MuscleGroupId, group.Id);
        Assert.Equal(muscleGroupName, group.Name);
        Assert.Equal(request.MuscleGroups[0].Role, group.Role);
    }

    private static void AssertEntityMatchesRequest(Exercise exercise, CreateExerciseRequest request)
    {
        Assert.Equal(request.Name, exercise.Name);
        Assert.Equal(request.Description, exercise.Description);
        Assert.Equal(request.EquipmentType, exercise.EquipmentType);
        Assert.Equal(request.MediaUrl, exercise.MediaUrl);
        Assert.Equal(request.TrackingMode, exercise.TrackingMode);
        Assert.False(exercise.IsBuiltIn);
    }

    private static Exercise CreateExercise(string name, Guid? id = null, bool isDeleted = false) => new()
    {
        Id = id ?? Guid.NewGuid(),
        Name = name,
        EquipmentType = EquipmentType.Barbell,
        TrackingMode = TrackingMode.RepsAndWeight,
        IsBuiltIn = true,
        IsDeleted = isDeleted
    };

    private static ExerciseMuscleGroup CreateExerciseMuscleGroup(Exercise exercise, string name, string role)
    {
        var muscleGroup = new MuscleGroup { Name = name };
        return new ExerciseMuscleGroup
        {
            Exercise = exercise,
            ExerciseId = exercise.Id,
            MuscleGroup = muscleGroup,
            Role = role
        };
    }

}
