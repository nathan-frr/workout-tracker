using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Application.Services.Exercises.DTOs;

public record ExerciseResponse(
    Guid Id,
    string Name,
    string? Description,
    EquipmentType EquipmentType,
    string? MediaUrl,
    TrackingMode TrackingMode,
    bool IsBuiltIn,
    IReadOnlyList<ExerciseMuscleGroupResponse> MuscleGroups);
