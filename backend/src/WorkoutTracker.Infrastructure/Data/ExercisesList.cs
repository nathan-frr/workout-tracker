using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data;

public static class ExercisesList
{
    public static readonly Exercise[] BuiltInExercises = [
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
            },
            new Exercise {
                Name = "Push-up",
                Description = "Push-up",
                IsBuiltIn = true,
                EquipmentType = EquipmentType.Bodyweight,
                TrackingMode = TrackingMode.Reps,
            }
    ];
}