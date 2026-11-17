namespace WorkoutTracker.Application.Services.Exercises;

using WorkoutTracker.Application.Services.Exercises.DTOs;

public interface IExercisesService
{
    Task<IReadOnlyList<ExerciseResponse>> GetAll(
        Guid userId,
        CancellationToken cancellationToken);
    Task<ExerciseResponse?> GetById(
        Guid id,
        Guid userId,
        CancellationToken cancellationToken);

    Task<ExerciseResponse> Create(
        CreateExerciseRequest request,
        Guid userId,
        CancellationToken cancellationToken);
}