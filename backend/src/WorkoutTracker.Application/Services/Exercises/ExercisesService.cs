using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Services.Exercises.DTOs;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Services.Exercises;

public sealed class ExercisesService(IApplicationDbContext context) : IExerciseService
{

    private static Expression<Func<Exercise, ExerciseResponse>> ToResponse =>
    exercise => new ExerciseResponse(
        exercise.Id,
        exercise.Name,
        exercise.Description,
        exercise.EquipmentType,
        exercise.MediaUrl,
        exercise.TrackingMode,
        exercise.IsBuiltIn,
        exercise.MuscleGroups
            .OrderBy(group => group.MuscleGroup.Name)
            .Select(group => new ExerciseMuscleGroupResponse(
                group.MuscleGroupId,
                group.MuscleGroup.Name,
                group.Role))
            .ToList());
    public async Task<IReadOnlyList<ExerciseResponse>> GetAll(
        CancellationToken cancellationToken)
    {
        return await context.Exercises
            .AsNoTracking()
            .Where(exercise => !exercise.IsDeleted)
            .OrderBy(exercise => exercise.Name)
            .Select(ToResponse)
            .ToListAsync(cancellationToken);
    }

    public async Task<ExerciseResponse> Create(
        CreateExerciseRequest request,
        CancellationToken cancellationToken)
    {
        var createdExercise = new Exercise
        {
            Name = request.Name,
            Description = request.Description,
            EquipmentType = request.EquipmentType,
            MediaUrl = request.MediaUrl,
            TrackingMode = request.TrackingMode,
            MuscleGroups = [.. request.MuscleGroups
                .Select(group => new ExerciseMuscleGroup
                {
                    MuscleGroupId = group.MuscleGroupId,
                    Role = group.Role
                })],
            CreatedByUserId = null,
        };
        context.Exercises.Add(createdExercise);
        await context.SaveChangesAsync(cancellationToken);

        return await context.Exercises
            .AsNoTracking()
            .Where(exercise => exercise.Id == createdExercise.Id)
            .Select(ToResponse)
            .SingleAsync(cancellationToken);

    }
}


