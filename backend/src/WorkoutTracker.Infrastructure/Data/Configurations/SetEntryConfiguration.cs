using WorkoutTracker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutTracker.Infrastructure.Data.Configurations;

public class SetEntryConfiguration : IEntityTypeConfiguration<SetEntry>
{
    public void Configure(EntityTypeBuilder<SetEntry> builder)
    {
        builder.Property(set => set.Weight).HasPrecision(8, 2);
        builder.Property(set => set.DistanceInMeters).HasPrecision(10, 2);
        builder.Property(set => set.Notes).HasMaxLength(500);
        builder.HasOne(set => set.WorkoutExercise)
            .WithMany(workoutExercise => workoutExercise.Sets)
            .HasForeignKey(set => set.WorkoutExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(set => new { set.WorkoutExerciseId, set.SetNumber })
            .IsUnique();
    }
}
