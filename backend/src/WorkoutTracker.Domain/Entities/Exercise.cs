using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Domain.Entities;

public class Exercise
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public EquipmentType EquipmentType { get; set; }

    public string? MediaUrl { get; set; }

    public TrackingMode TrackingMode { get; set; }

    public bool IsBuiltIn { get; set; }

    public Guid? CreatedByUserId { get; set; }

    public ICollection<ExerciseMuscleGroup> MuscleGroups
    { get; set; } = [];
}