using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Api.Controllers;
using WorkoutTracker.Application.Services.Exercises;
using WorkoutTracker.Application.Services.Exercises.DTOs;
using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.UnitTests.Controllers;

public sealed class ExercisesControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOkWithExercisesAndForwardsCancellationToken()
    {
        var expected = new ExerciseResponse[]
        {
            new(
                Id: Guid.NewGuid(),
                Name: "Bench press",
                Description: null,
                EquipmentType: EquipmentType.Barbell,
                MediaUrl: null,
                TrackingMode: TrackingMode.RepsAndWeight,
                IsBuiltIn: true,
                MuscleGroups: [])
        };
        var service = new StubExerciseService(expected, expected[0]);
        var controller = new ExercisesController(service);
        var cancellationToken = new CancellationToken(canceled: false);

        var actionResult = await controller.GetAll(cancellationToken);

        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Same(expected, okResult.Value);
        Assert.Equal(cancellationToken, service.ReceivedCancellationToken);
    }

    [Fact]
    public async Task Create_ReturnsOkWithExercisesAndForwardsCancellationToken()
    {
        var request = new CreateExerciseRequest(
            Name: "Bench press",
            Description: null,
            EquipmentType: EquipmentType.Barbell,
            MediaUrl: null,
            TrackingMode: TrackingMode.RepsAndWeight,
            MuscleGroups: [],
            CreatedByUserId: null
        );
        var expected = new ExerciseResponse[]
        {
            new(
                Guid.NewGuid(),
                "Bench press",
                null,
                EquipmentType.Barbell,
                null,
                TrackingMode.RepsAndWeight,
                true,
                [])
        };
        var service = new StubExerciseService(expected, expected[0]);
        var controller = new ExercisesController(service);
        var cancellationToken = new CancellationToken(canceled: false);

        var actionResult = await controller.Create(request, cancellationToken);

        var okResult = Assert.IsType<CreatedResult>(actionResult.Result);
        Assert.Same(expected[0], okResult.Value);
        Assert.Equal(cancellationToken, service.ReceivedCancellationToken);
    }

    private sealed class StubExerciseService(
        IReadOnlyList<ExerciseResponse> exercises,
        ExerciseResponse createdExercise) : IExerciseService
    {
        public CancellationToken? ReceivedCancellationToken { get; private set; }

        public Task<IReadOnlyList<ExerciseResponse>> GetAll(
            CancellationToken cancellationToken)
        {
            ReceivedCancellationToken = cancellationToken;
            return Task.FromResult(exercises);
        }

        public Task<ExerciseResponse> Create(
            CreateExerciseRequest request,
            CancellationToken cancellationToken)
        {
            ReceivedCancellationToken = cancellationToken;
            return Task.FromResult(createdExercise);
        }
    }
}
