namespace WorkoutTracker.Application.Services.Exercises;

using WorkoutTracker.Application.Services.Exercises.DTOs;

public interface IExercisesService
{
    Task<IReadOnlyList<ExerciseResponse>> GetAll(
        CancellationToken cancellationToken);
    Task<ExerciseResponse?> GetById(
        Guid id,
        CancellationToken cancellationToken);

    Task<ExerciseResponse> Create(
        CreateExerciseRequest request,
        CancellationToken cancellationToken);
}