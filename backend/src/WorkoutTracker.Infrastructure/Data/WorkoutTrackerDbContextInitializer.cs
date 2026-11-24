using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        var existingExerciseNames = await _context.Exercises
            .Where(e => e.IsBuiltIn)
            .Select(e => e.AssetId)
            .ToHashSetAsync();

        var missingExercises = ExercisesList.BuiltInExercises
            .Where(e => !existingExerciseNames.Contains(e.AssetId))
            .ToArray();

        if (missingExercises.Length > 0)
        {
            _context.Exercises.AddRange(missingExercises);

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
                .ToDictionaryAsync(e => e.AssetId!);

            exercises["bench-press"].MuscleGroups.Add(new ExerciseMuscleGroup
            {
                MuscleGroup = muscleGroups["Chest"]
            });

            await _context.SaveChangesAsync();
        }
    }
}