namespace WorkoutTracker.Application.Services.Workouts;

using WorkoutTracker.Application.Services.Workouts.DTOs;

public interface IWorkoutsService
{
    Task<IReadOnlyList<WorkoutResponse>> GetAll(
        CancellationToken cancellationToken);
    Task<WorkoutResponse?> GetById(
        Guid id,
        CancellationToken cancellationToken);

    Task<WorkoutResponse> Create(
        CreateWorkoutRequest request,
        CancellationToken cancellationToken);
}