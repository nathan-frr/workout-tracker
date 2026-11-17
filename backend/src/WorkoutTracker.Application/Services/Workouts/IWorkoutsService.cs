namespace WorkoutTracker.Application.Services.Workouts;

using WorkoutTracker.Application.Services.Workouts.DTOs;

public interface IWorkoutsService
{
    Task<IReadOnlyList<WorkoutResponse>> GetAll(
        Guid userId,
        CancellationToken cancellationToken);
    Task<WorkoutResponse?> GetById(
        Guid id,
        Guid userId,
        CancellationToken cancellationToken);

    Task<WorkoutResponse> Create(
        CreateWorkoutRequest request,
        Guid userId,
        CancellationToken cancellationToken);
}