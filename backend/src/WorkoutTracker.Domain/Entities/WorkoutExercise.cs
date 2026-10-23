namespace WorkoutTracker.Domain.Entities;

public class WorkoutExercise
{
    public Guid Id { get; set; }

    public Guid WorkoutSessionId { get; set; }
    public WorkoutSession WorkoutSession { get; set; } = null!;

    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;

    public int Order { get; set; }

    public ICollection<SetEntry> Sets { get; set; } = [];
}