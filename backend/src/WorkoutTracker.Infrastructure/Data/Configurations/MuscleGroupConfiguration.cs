using WorkoutTracker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutTracker.Infrastructure.Data.Configurations;

public class MuscleGroupConfiguration : IEntityTypeConfiguration<MuscleGroup>
{
    public void Configure(EntityTypeBuilder<MuscleGroup> builder)
    {
        builder.Property(muscleGroup => muscleGroup.Name)
            .HasMaxLength(120)
            .IsRequired();
        builder.HasIndex(muscleGroup => muscleGroup.Name)
            .IsUnique();
    }
}
