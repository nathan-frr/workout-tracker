namespace WorkoutTracker.Domain.Entities;

public class ExerciseMuscleGroup
{
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;

    public int MuscleGroupId { get; set; }
    public MuscleGroup MuscleGroup { get; set; } = null!;

    public string Role { get; set; } = "Primary";
}