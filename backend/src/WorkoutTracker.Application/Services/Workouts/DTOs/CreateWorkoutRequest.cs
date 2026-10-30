using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Application.Services.Workouts.DTOs;

public record CreateWorkoutRequest(
    string Title,
    DateOnly WorkoutDate,
    DateTimeOffset? StartedAtTime,
    int? DurationInMinutes,
    string? Location,
    WorkoutType? WorkoutType,
    string? Notes,
    IReadOnlyList<CreateWorkoutExerciseRequest> Exercises);

public record CreateWorkoutExerciseRequest(
    Guid ExerciseId,
    int Order,
    IReadOnlyList<CreateSetEntryRequest> Sets);

public record CreateSetEntryRequest(
    int SetNumber,
    int? Reps,
    decimal? Weight,
    int? DurationInSeconds,
    decimal? DistanceInMeters,
    bool IsCompleted,
    string? Notes);