using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Application.Services.Workouts.DTOs;

public record WorkoutResponse(
    Guid Id,
    string Title,
    DateOnly WorkoutDate,
    DateTimeOffset? StartedAtTime,
    int? DurationInMinutes,
    string? Location,
    WorkoutType? WorkoutType,
    string? Notes,
    DateTimeOffset CreatedAt,
    IReadOnlyList<WorkoutExerciseResponse> Exercises);

public record WorkoutExerciseResponse(
    Guid Id,
    ExerciseSummaryResponse Exercise,
    int Order,
    IReadOnlyList<SetEntryResponse> Sets);

public record ExerciseSummaryResponse(
    Guid Id,
    string Name,
    string? MediaUrl,
    EquipmentType EquipmentType,
    TrackingMode TrackingMode);

public record SetEntryResponse(
    Guid Id,
    int SetNumber,
    int? Reps,
    decimal? Weight,
    int? DurationInSeconds,
    decimal? DistanceInMeters,
    bool IsCompleted,
    string? Notes);
