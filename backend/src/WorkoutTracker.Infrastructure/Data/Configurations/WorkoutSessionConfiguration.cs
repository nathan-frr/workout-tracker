using WorkoutTracker.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkoutTracker.Infrastructure.Data.Configurations;

public class WorkoutSessionConfiguration : IEntityTypeConfiguration<WorkoutSession>
{
    public void Configure(EntityTypeBuilder<WorkoutSession> builder)
    {
        builder.Property(session => session.Title)
            .HasMaxLength(160)
            .IsRequired();
        builder.Property(session => session.Location)
            .HasMaxLength(160);
        builder.Property(session => session.Notes)
            .HasMaxLength(2000);
        builder.HasIndex(session => new { session.UserId, session.WorkoutDate });
    }
}
