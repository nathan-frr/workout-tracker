namespace WorkoutTracker.Domain.Entities;

public class SetEntry
{
    public Guid Id { get; set; }

    public Guid WorkoutExerciseId { get; set; }

    public int SetNumber { get; set; }

    public int? Reps { get; set; }

    public decimal? Weight { get; set; }

    public int? DurationInSeconds { get; set; }

    public decimal? DistanceInMeters { get; set; }

    public bool IsCompleted { get; set; }

    public string? Notes { get; set; }

    public WorkoutExercise WorkoutExercise { get; set; } = null!;
}