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
        ValidateRequest(request);

        var requestedMuscleGroupIds = request.MuscleGroups
            .Select(group => group.MuscleGroupId)
            .Distinct()
            .ToArray();
        var existingMuscleGroupIds = await context.MuscleGroups
            .AsNoTracking()
            .Where(muscleGroup => requestedMuscleGroupIds.Contains(muscleGroup.Id))
            .Select(muscleGroup => muscleGroup.Id)
            .ToListAsync(cancellationToken);
        var missingMuscleGroupIds = requestedMuscleGroupIds
            .Except(existingMuscleGroupIds)
            .ToArray();

        if (missingMuscleGroupIds.Length > 0)
        {
            throw new ArgumentException(
                $"The following muscle groups do not exist: {string.Join(", ", missingMuscleGroupIds)}.");
        }

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

    private static void ValidateRequest(CreateExerciseRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Name is required.");
        }

        if (request.Name.Length > 120)
        {
            throw new ArgumentException("Name cannot exceed 120 characters.");
        }

        if (request.Description?.Length > 1000)
        {
            throw new ArgumentException("Description cannot exceed 1000 characters.");
        }

        if (request.MediaUrl?.Length > 2048)
        {
            throw new ArgumentException("MediaUrl cannot exceed 2048 characters.");
        }

        if (!Enum.IsDefined(request.EquipmentType))
        {
            throw new ArgumentException("EquipmentType is invalid.");
        }

        if (!Enum.IsDefined(request.TrackingMode))
        {
            throw new ArgumentException("TrackingMode is invalid.");
        }

        if (request.MuscleGroups is null)
        {
            throw new ArgumentException("MuscleGroups cannot be null.");
        }

        if (request.MuscleGroups
            .GroupBy(group => group.MuscleGroupId)
            .Any(group => group.Count() > 1))
        {
            throw new ArgumentException("A muscle group cannot be added more than once.");
        }

        foreach (var muscleGroup in request.MuscleGroups)
        {
            if (string.IsNullOrWhiteSpace(muscleGroup.Role))
            {
                throw new ArgumentException("Muscle-group role is required.");
            }

            if (muscleGroup.Role.Length > 20)
            {
                throw new ArgumentException("Muscle-group role cannot exceed 20 characters.");
            }
        }
    }
}


