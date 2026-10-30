using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Services.Exercises.DTOs;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Services.Exercises;

public sealed class ExercisesService(IApplicationDbContext context) : IExercisesService
{

    private static Expression<Func<Exercise, ExerciseResponse>> ToResponse =>
    exercise => new ExerciseResponse(
        Id: exercise.Id,
        Name: exercise.Name,
        Description: exercise.Description,
        EquipmentType: exercise.EquipmentType,
        MediaUrl: exercise.MediaUrl,
        TrackingMode: exercise.TrackingMode,
        IsBuiltIn: exercise.IsBuiltIn,
        MuscleGroups: exercise.MuscleGroups
            .OrderBy(group => group.MuscleGroup.Name)
            .Select(group => new ExerciseMuscleGroupResponse(
                Id: group.MuscleGroupId,
                Name: group.MuscleGroup.Name,
                Role: group.Role))
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
    public async Task<ExerciseResponse?> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await context.Exercises
            .AsNoTracking()
            .Where(exercise => !exercise.IsDeleted && exercise.Id == id)
            .Select(ToResponse)
            .SingleOrDefaultAsync(cancellationToken);
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


