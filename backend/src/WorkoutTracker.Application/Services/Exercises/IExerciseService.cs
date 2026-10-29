namespace WorkoutTracker.Application.Services.Exercises;

using WorkoutTracker.Application.Services.Exercises.DTOs;

public interface IExerciseService
{
    Task<IReadOnlyList<ExerciseResponse>> GetAll(
        CancellationToken cancellationToken);

    Task<ExerciseResponse> Create(
        CreateExerciseRequest request,
        CancellationToken cancellationToken);
}