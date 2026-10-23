using WorkoutTracker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutTracker.Infrastructure.Data.Configurations;

public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
{
    public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
    {
        builder.HasOne(workoutExercise => workoutExercise.WorkoutSession)
            .WithMany(session => session.Exercises)
            .HasForeignKey(workoutExercise => workoutExercise.WorkoutSessionId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(workoutExercise => workoutExercise.Exercise)
            .WithMany()
            .HasForeignKey(workoutExercise => workoutExercise.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(workoutExercise => new { workoutExercise.WorkoutSessionId, workoutExercise.Order })
            .IsUnique();
    }
}
