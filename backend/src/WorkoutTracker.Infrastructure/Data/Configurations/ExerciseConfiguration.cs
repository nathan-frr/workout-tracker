using WorkoutTracker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutTracker.Infrastructure.Data.Configurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.Property(exercise => exercise.Name)
            .HasMaxLength(120)
            .IsRequired();
        builder.Property(exercise => exercise.Description)
            .HasMaxLength(1000);
        builder.Property(exercise => exercise.MediaUrl)
            .HasMaxLength(2048);
        builder.Property(exercise => exercise.IsDeleted)
            .HasDefaultValue(false);
        builder.HasIndex(exercise => exercise.IsDeleted);
    }
}
