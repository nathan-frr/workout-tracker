using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Application.Services.Exercises;
using WorkoutTracker.Application.Services.Exercises.DTOs;

using WorkoutTracker.Api.Helpers;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ExercisesController(IExercisesService exerciseService) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IReadOnlyList<ExerciseResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var userId = UserHelper.GetUserId(User);
        var exercises = await exerciseService.GetAll(userId, cancellationToken);
        return Ok(exercises);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<ExerciseResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var userId = UserHelper.GetUserId(User);
        var exercise = await exerciseService.GetById(id, userId, cancellationToken);

        return exercise is null ? NotFound() : Ok(exercise);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ExerciseResponse>> Create(
        CreateExerciseRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var userId = UserHelper.GetUserId(User);
            var exercise = await exerciseService.Create(request, userId, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
        }
        catch (ArgumentException exception)
        {
            return ValidationProblem(detail: exception.Message);
        }
    }
}

