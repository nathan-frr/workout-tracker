using WorkoutTracker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutTracker.Infrastructure.Data.Configurations;

public class ExerciseMuscleGroupConfiguration : IEntityTypeConfiguration<ExerciseMuscleGroup>
{
    public void Configure(EntityTypeBuilder<ExerciseMuscleGroup> builder)
    {
        builder.HasKey(link => new { link.ExerciseId, link.MuscleGroupId });
        builder.Property(link => link.Role)
            .HasMaxLength(20)
            .IsRequired();
        builder.HasOne(link => link.Exercise)
            .WithMany(exercise => exercise.MuscleGroups)
            .HasForeignKey(link => link.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(link => link.MuscleGroup)
            .WithMany(group => group.Exercises)
            .HasForeignKey(link => link.MuscleGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
