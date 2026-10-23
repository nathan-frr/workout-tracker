using WorkoutTracker.Domain.Enums;

namespace WorkoutTracker.Domain.Entities;

public class WorkoutSession
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public required string Title { get; set; }

    public DateOnly WorkoutDate { get; set; }

    public DateTimeOffset? StartedAtTime { get; set; }

    public int? DurationInMinutes { get; set; }

    public string? Location { get; set; }

    public WorkoutType? WorkoutType { get; set; }

    public string? Notes { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public ICollection<WorkoutExercise> Exercises { get; set; } = [];
}