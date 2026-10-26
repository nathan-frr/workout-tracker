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
                Guid.NewGuid(),
                "Bench press",
                null,
                EquipmentType.Barbell,
                null,
                TrackingMode.RepsAndWeight,
                true,
                [])
        };
        var service = new StubExerciseService(expected);
        var controller = new ExercisesController(service);
        var cancellationToken = new CancellationToken(canceled: false);

        var actionResult = await controller.GetAll(cancellationToken);

        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.Same(expected, okResult.Value);
        Assert.Equal(cancellationToken, service.ReceivedCancellationToken);
    }

    private sealed class StubExerciseService(IReadOnlyList<ExerciseResponse> exercises) : IExerciseService
    {
        public CancellationToken? ReceivedCancellationToken { get; private set; }

        public Task<IReadOnlyList<ExerciseResponse>> GetAll(CancellationToken cancellationToken)
        {
            ReceivedCancellationToken = cancellationToken;
            return Task.FromResult(exercises);
        }
    }
}
