using System.Net.Http.Json;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Npgsql;

using WorkoutTracker.Application.Services.Exercises.DTOs;
using WorkoutTracker.Domain.Entities;
using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Infrastructure.Data;

namespace WorkoutTracker.IntegrationTests;

public sealed class ExercisesEndpointTests
{
    [Fact]
    public async Task GetExercises_ReturnsActiveExercisesOrderedWithMuscleGroups()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<ExercisesEndpointTests>(optional: true)
            .AddEnvironmentVariables()
            .Build();
        var connectionString =
            configuration.GetConnectionString("WorkoutTrackerTest")
            ?? throw new InvalidOperationException(
                "Set ConnectionStrings:WorkoutTrackerTest with User Secrets or an environment variable before running integration tests.");

        var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        if (connectionStringBuilder.Database != "workout_tracker_test")
        {
            throw new InvalidOperationException(
                "Integration tests can only run against the dedicated 'workout_tracker_test' database.");
        }

        using var factory = new WorkoutTrackerApiFactory(connectionString);
        using var client = factory.CreateClient();

        await using var scope = factory.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<WorkoutTrackerDbContext>();
        await context.Database.MigrateAsync();

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

            using var response = await client.GetAsync("/api/exercises");
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

    private sealed class WorkoutTrackerApiFactory(string connectionString) : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureHostConfiguration(configuration =>
              configuration.AddInMemoryCollection(
                new Dictionary<string, string?>
                {
                    ["ConnectionStrings:WorkoutTracker"] = connectionString
                }));

            return base.CreateHost(builder);
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
        }
    }
}
