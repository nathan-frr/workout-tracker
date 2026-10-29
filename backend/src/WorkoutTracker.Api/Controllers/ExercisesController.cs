using Microsoft.AspNetCore.Mvc;

using WorkoutTracker.Application.Services.Exercises;
using WorkoutTracker.Application.Services.Exercises.DTOs;

namespace WorkoutTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ExercisesController(IExerciseService exerciseService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ExerciseResponse>>> GetAll(
        CancellationToken cancellationToken)
    {
        var exercises = await exerciseService.GetAll(cancellationToken);
        return Ok(exercises);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ExerciseResponse>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var exercise = await exerciseService.GetById(id, cancellationToken);

        return exercise is null ? NotFound() : Ok(exercise);
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseResponse>> Create(
    CreateExerciseRequest request,
    CancellationToken cancellationToken)
    {
        var exercise = await exerciseService.Create(request, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
    }
}

