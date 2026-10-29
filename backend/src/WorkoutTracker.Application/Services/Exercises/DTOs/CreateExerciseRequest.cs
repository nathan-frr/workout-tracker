using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Application.Services.Exercises.DTOs;

public record CreateExerciseRequest(
    string Name,
    string? Description,
    EquipmentType EquipmentType,
    string? MediaUrl,
    TrackingMode TrackingMode,
    IReadOnlyList<CreateExerciseMuscleGroupRequest> MuscleGroups,
    string? CreatedByUserId);

public record CreateExerciseMuscleGroupRequest(
    int MuscleGroupId,
    string Role);