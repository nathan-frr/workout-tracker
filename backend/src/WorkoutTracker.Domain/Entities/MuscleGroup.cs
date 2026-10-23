namespace WorkoutTracker.Domain.Entities;

public class MuscleGroup
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<ExerciseMuscleGroup> Exercises
    { get; set; } = [];
}