using Microsoft.EntityFrameworkCore;

using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Services.Exercises.DTOs;

namespace WorkoutTracker.Application.Services.Exercises;

public sealed class ExercisesService(IApplicationDbContext context) : IExerciseService
{
    public async Task<IReadOnlyList<ExerciseResponse>> GetAll(
        CancellationToken cancellationToken)
    {
        return await context.Exercises
            .AsNoTracking()
            .Where(exercise => !exercise.IsDeleted)
            .OrderBy(exercise => exercise.Name)
            .Select(exercise => new ExerciseResponse(
                exercise.Id,
                exercise.Name,
                exercise.Description,
                exercise.EquipmentType,
                exercise.MediaUrl,
                exercise.TrackingMode,
                exercise.IsBuiltIn,
                exercise.MuscleGroups
                    .OrderBy(exerciseMuscleGroup => exerciseMuscleGroup.MuscleGroup.Name)
                    .Select(exerciseMuscleGroup => new ExerciseMuscleGroupResponse(
                        exerciseMuscleGroup.MuscleGroupId,
                        exerciseMuscleGroup.MuscleGroup.Name,
                        exerciseMuscleGroup.Role))
                    .ToList()))
            .ToListAsync(cancellationToken);
    }
}
