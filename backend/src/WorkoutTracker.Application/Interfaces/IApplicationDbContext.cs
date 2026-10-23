using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Exercise> Exercises { get; }
    DbSet<ExerciseMuscleGroup> ExerciseMuscleGroups { get; }
    DbSet<MuscleGroup> MuscleGroups { get; }
    DbSet<SetEntry> SetEntries { get; }
    DbSet<WorkoutExercise> WorkoutExercises { get; }
    DbSet<WorkoutSession> WorkoutSessions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
