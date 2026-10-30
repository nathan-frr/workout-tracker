using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Services.Workouts.DTOs;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Application.Services.Workouts;

public sealed class WorkoutsService(IApplicationDbContext context) : IWorkoutsService
{

    private static Expression<Func<WorkoutSession, WorkoutResponse>> ToResponse =>
    workout => new WorkoutResponse(
        Id: workout.Id,
        Title: workout.Title,
        WorkoutDate: workout.WorkoutDate,
        StartedAtTime: workout.StartedAtTime,
        DurationInMinutes: workout.DurationInMinutes,
        Location: workout.Location,
        WorkoutType: workout.WorkoutType,
        Notes: workout.Notes,
        CreatedAt: workout.CreatedAt,
        Exercises: workout.Exercises
            .OrderBy(workoutExercise => workoutExercise.Order)
            .Select(workoutExercise => new WorkoutExerciseResponse(
                Id: workoutExercise.Id,
                Exercise: new ExerciseSummaryResponse(
                    Id: workoutExercise.Exercise.Id,
                    Name: workoutExercise.Exercise.Name,
                    MediaUrl: workoutExercise.Exercise.MediaUrl,
                    EquipmentType: workoutExercise.Exercise.EquipmentType,
                    TrackingMode: workoutExercise.Exercise.TrackingMode),
                Order: workoutExercise.Order,
                Sets: workoutExercise.Sets
                    .OrderBy(setEntry => setEntry.SetNumber)
                    .Select(setEntry => new SetEntryResponse(
                        Id: setEntry.Id,
                        SetNumber: setEntry.SetNumber,
                        Reps: setEntry.Reps,
                        Weight: setEntry.Weight,
                        DurationInSeconds: setEntry.DurationInSeconds,
                        DistanceInMeters: setEntry.DistanceInMeters,
                        IsCompleted: setEntry.IsCompleted,
                        Notes: setEntry.Notes))
                    .ToList()))
            .ToList());
    public async Task<IReadOnlyList<WorkoutResponse>> GetAll(
        CancellationToken cancellationToken)
    {
        return await context.WorkoutSessions
            .AsNoTracking()
            .OrderByDescending(workout => workout.WorkoutDate)
            .Select(ToResponse)
            .ToListAsync(cancellationToken);
    }
    public async Task<WorkoutResponse?> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await context.WorkoutSessions
            .AsNoTracking()
            .Where(workout => workout.Id == id)
            .Select(ToResponse)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<WorkoutResponse> Create(
        CreateWorkoutRequest request,
        CancellationToken cancellationToken)
    {
        ValidateRequest(request);

        var requestedExerciseIds = request.Exercises
            .Select(workoutExercise => workoutExercise.ExerciseId)
            .Distinct()
            .ToArray();
        var existingExerciseIds = await context.Exercises
            .AsNoTracking()
            .Where(exercise => !exercise.IsDeleted && requestedExerciseIds.Contains(exercise.Id))
            .Select(exercise => exercise.Id)
            .ToListAsync(cancellationToken);
        var missingExerciseIds = requestedExerciseIds
            .Except(existingExerciseIds)
            .ToArray();

        if (missingExerciseIds.Length > 0)
        {
            throw new ArgumentException(
                $"The following exercises do not exist or are unavailable: {string.Join(", ", missingExerciseIds)}.");
        }

        var createdWorkout = new WorkoutSession
        {
            UserId = Guid.NewGuid(), //Placeholder until realy auth
            Title = request.Title,
            WorkoutDate = request.WorkoutDate,
            StartedAtTime = request.StartedAtTime,
            DurationInMinutes = request.DurationInMinutes,
            Location = request.Location,
            WorkoutType = request.WorkoutType,
            Notes = request.Notes,
            CreatedAt = DateTimeOffset.UtcNow,
            Exercises = [.. request.Exercises
                .Select(workoutExercise => new WorkoutExercise
                {
                    ExerciseId = workoutExercise.ExerciseId,
                    Order = workoutExercise.Order,
                    Sets = [.. workoutExercise.Sets
                        .Select(setEntry => new SetEntry
                        {
                            SetNumber = setEntry.SetNumber,
                            Reps = setEntry.Reps,
                            Weight = setEntry.Weight,
                            DurationInSeconds = setEntry.DurationInSeconds,
                            DistanceInMeters = setEntry.DistanceInMeters,
                            IsCompleted = setEntry.IsCompleted,
                            Notes = setEntry.Notes
                        })]
                })]
        };
        context.WorkoutSessions.Add(createdWorkout);
        await context.SaveChangesAsync(cancellationToken);

        return await context.WorkoutSessions
            .AsNoTracking()
            .Where(workout => workout.Id == createdWorkout.Id)
            .Select(ToResponse)
            .SingleAsync(cancellationToken);

    }

    private static void ValidateRequest(CreateWorkoutRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Title is required.");
        }

        if (request.Title.Length > 160)
        {
            throw new ArgumentException("Title cannot exceed 160 characters.");
        }

        if (request.Location?.Length > 160)
        {
            throw new ArgumentException("Location cannot exceed 160 characters.");
        }

        if (request.Notes?.Length > 2000)
        {
            throw new ArgumentException("Notes cannot exceed 2000 characters.");
        }

        if (request.DurationInMinutes < 0)
        {
            throw new ArgumentException("DurationInMinutes cannot be negative.");
        }

        if (request.Exercises is null || request.Exercises.Count == 0)
        {
            throw new ArgumentException("At least one exercise is required.");
        }

        if (request.Exercises
            .GroupBy(workoutExercise => workoutExercise.ExerciseId)
            .Any(group => group.Count() > 1))
        {
            throw new ArgumentException("An exercise cannot be added more than once to a workout.");
        }

        if (request.Exercises
            .GroupBy(workoutExercise => workoutExercise.Order)
            .Any(group => group.Count() > 1))
        {
            throw new ArgumentException("Exercise order values must be unique.");
        }

        foreach (var workoutExercise in request.Exercises)
        {
            if (workoutExercise.Order <= 0)
            {
                throw new ArgumentException("Exercise order must be greater than zero.");
            }

            if (workoutExercise.Sets is null || workoutExercise.Sets.Count == 0)
            {
                throw new ArgumentException("Each exercise must contain at least one set.");
            }

            if (workoutExercise.Sets
                .GroupBy(setEntry => setEntry.SetNumber)
                .Any(group => group.Count() > 1))
            {
                throw new ArgumentException("Set number values must be unique within an exercise.");
            }

            foreach (var setEntry in workoutExercise.Sets)
            {
                if (setEntry.SetNumber <= 0)
                {
                    throw new ArgumentException("Set number must be greater than zero.");
                }

                if (setEntry.Reps < 0 ||
                    setEntry.Weight < 0 ||
                    setEntry.DurationInSeconds < 0 ||
                    setEntry.DistanceInMeters < 0)
                {
                    throw new ArgumentException("Set values cannot be negative.");
                }

                if (setEntry.Weight > 999999.99m)
                {
                    throw new ArgumentException("Weight cannot exceed 999999.99.");
                }

                if (setEntry.DistanceInMeters > 99999999.99m)
                {
                    throw new ArgumentException("DistanceInMeters cannot exceed 99999999.99.");
                }
            }
        }
    }
}


