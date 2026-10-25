using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data;

public class WorkoutTrackerDbContextInitializer
{
    private readonly ILogger<WorkoutTrackerDbContextInitializer> _logger;
    private readonly WorkoutTrackerDbContext _context;

    public WorkoutTrackerDbContextInitializer(
        ILogger<WorkoutTrackerDbContextInitializer> logger,
        WorkoutTrackerDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            // Apply pending EF Core migrations.
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An error occurred while Initializing the database.");

            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An error occurred while seeding the database.");

            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        // Seed built-in exercises if they don't already exist.
        // TODO: check each exercise individually and only add missing ones.
        if (!await _context.Exercises.AnyAsync(e => e.IsBuiltIn))
        {
            _context.Exercises.AddRange(
                new Exercise
                {
                    Name = "Bench Press",
                    Description = "Barbell chest press",
                    IsBuiltIn = true,
                    EquipmentType = EquipmentType.Barbell,
                    TrackingMode = TrackingMode.RepsAndWeight
                },
                new Exercise
                {
                    Name = "Squat",
                    Description = "Barbell back squat",
                    IsBuiltIn = true,
                    EquipmentType = EquipmentType.Barbell,
                    TrackingMode = TrackingMode.RepsAndWeight
                },
                new Exercise
                {
                    Name = "Deadlift",
                    Description = "Conventional barbell deadlift",
                    IsBuiltIn = true,
                    EquipmentType = EquipmentType.Barbell,
                    TrackingMode = TrackingMode.RepsAndWeight
                },
                new Exercise
                {
                    Name = "Pull-up",
                    Description = "Bodyweight vertical pull",
                    IsBuiltIn = true,
                    EquipmentType = EquipmentType.Bodyweight,
                    TrackingMode = TrackingMode.Reps
                },
                new Exercise
                {
                    Name = "Shoulder Press",
                    Description = "Dumbbell shoulder press",
                    IsBuiltIn = true,
                    EquipmentType = EquipmentType.Dumbbell,
                    TrackingMode = TrackingMode.RepsAndWeight
                });

            await _context.SaveChangesAsync();
        }

        if (!await _context.MuscleGroups.AnyAsync())
        {
            _context.MuscleGroups.AddRange(
                new MuscleGroup { Name = "Chest" },
                new MuscleGroup { Name = "Back" },
                new MuscleGroup { Name = "Legs" },
                new MuscleGroup { Name = "Shoulders" },
                new MuscleGroup { Name = "Arms" },
                new MuscleGroup { Name = "Core" });

            await _context.SaveChangesAsync();
        }

        if (!await _context.ExerciseMuscleGroups.AnyAsync())
        {
            var muscleGroups = await _context.MuscleGroups.ToDictionaryAsync(g => g.Name);
            var exercises = await _context.Exercises
                .Where(e => e.IsBuiltIn)
                .ToDictionaryAsync(e => e.Name);

            exercises["Bench Press"].MuscleGroups.Add(new ExerciseMuscleGroup
            {
                MuscleGroup = muscleGroups["Chest"]
            });

            await _context.SaveChangesAsync();
        }
    }
}