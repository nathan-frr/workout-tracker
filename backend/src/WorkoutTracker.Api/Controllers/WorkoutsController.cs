using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Application.Services.Workouts;
using WorkoutTracker.Application.Services.Workouts.DTOs;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class WorkoutsController(IWorkoutsService workoutService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<WorkoutResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var workouts = await workoutService.GetAll(cancellationToken);
        return Ok(workouts);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<WorkoutResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var workout = await workoutService.GetById(id, cancellationToken);

        return workout is null ? NotFound() : Ok(workout);
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutResponse>> Create(
        CreateWorkoutRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var workout = await workoutService.Create(request, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = workout.Id }, workout);
        }
        catch (ArgumentException exception)
        {
            return ValidationProblem(detail: exception.Message);
        }
    }
}

