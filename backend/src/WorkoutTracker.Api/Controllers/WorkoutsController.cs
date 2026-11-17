using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Application.Services.Workouts;
using WorkoutTracker.Application.Services.Workouts.DTOs;

using WorkoutTracker.Api.Helpers;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class WorkoutsController(IWorkoutsService workoutService) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IReadOnlyList<WorkoutResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var userId = UserHelper.GetUserId(User);
        var workouts = await workoutService.GetAll(userId, cancellationToken);
        return Ok(workouts);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<WorkoutResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var userId = UserHelper.GetUserId(User);
        var workout = await workoutService.GetById(id, userId, cancellationToken);

        return workout is null ? NotFound() : Ok(workout);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<WorkoutResponse>> Create(
        CreateWorkoutRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var userId = UserHelper.GetUserId(User);
            var workout = await workoutService.Create(request, userId, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = workout.Id }, workout);
        }
        catch (ArgumentException exception)
        {
            return ValidationProblem(detail: exception.Message);
        }
    }
}

