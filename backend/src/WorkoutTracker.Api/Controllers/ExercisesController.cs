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
}
