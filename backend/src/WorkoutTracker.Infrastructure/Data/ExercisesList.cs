using WorkoutTracker.Domain.Enums;
using WorkoutTracker.Domain.Entities;

namespace WorkoutTracker.Infrastructure.Data;

public static class ExercisesList
{
    public static readonly Exercise[] BuiltInExercises = [
            new Exercise
            {
                Name = "Ab Wheel Rollout",
                Description = "A core exercise rolling a wheel forward and back, training anti-extension of the spine.",
                EquipmentType = EquipmentType.Other,
                AssetId = "ab-wheel-rollout",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Back Extension",
                Description = "An isolation movement targeting the lower back erector spinae on a hyperextension bench.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "back-extension",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Barbell Curl",
                Description = "A classic biceps isolation exercise using a barbell for maximal loading.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "barbell-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Barbell Preacher Curl",
                Description = "This isolation exercise targets the biceps brachii and brachialis by fixing the upper arms on a preacher bench, minimizing momentum and maximizing tension.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "barbell-preacher-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Barbell Row",
                Description = "A compound pulling movement that targets the upper and middle back.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "barbell-row",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bench Dips",
                Description = "A bodyweight pressing movement with hands on a bench behind the body, emphasizing the triceps.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "bench-dips",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bench Press",
                Description = "A compound pushing movement that targets the chest, shoulders, and triceps.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bent Arm Barbell Pullover",
                Description = "A pullover variation performed with elbows bent, lowering a barbell behind the head to stretch the lats and chest.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "bent-arm-barbell-pullover",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Bicep Curl",
                Description = "An isolation exercise targeting the biceps.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "bicep-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bodyweight Calf Raise",
                Description = "A beginner-friendly calf raise using body weight only on flat ground, strengthening the gastrocnemius and soleus.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "bodyweight-calf-raise",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bodyweight Lateral Raise",
                Description = "A shoulder isolation movement performed without equipment to develop lateral deltoid width.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "bodyweight-lateral-raise",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bodyweight Squat",
                Description = "A foundational lower-body exercise squatting with body weight only, developing the quadriceps, glutes, and basic movement mechanics.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "bodyweight-squat",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Bulgarian Split Squat",
                Description = "A single-leg squat variation with the rear foot elevated.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "bulgarian-split-squat",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Chest Press",
                Description = "A standing chest press on the cable machine, providing constant tension while the staggered stance demands core stability.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-chest-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Crunch",
                Description = "A kneeling abdominal exercise flexing the spine against cable resistance, allowing progressive loading of the rectus abdominis.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-crunch",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Curl",
                Description = "A bicep curl using cable resistance for constant tension.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Fly",
                Description = "An isolation movement for the chest using cable resistance for constant tension.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-fly",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Front Raise",
                Description = "An isolation exercise raising a cable handle to shoulder height, keeping constant tension on the front delt.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-front-raise",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Lateral Raise",
                Description = "A unilateral lateral raise on the cable, providing constant tension on the side delt.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-lateral-raise",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Overhead Tricep Extension",
                Description = "A cable triceps exercise: facing away from the weight stack, you hold a rope behind your head and straighten your elbows to push it up and overhead. The overhead position stretches the long head of the triceps, and the cable keeps tension on the muscle through the whole movement.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "cable-overhead-tricep-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Chest Press",
                Description = "A machine-based pressing movement for the chest, ideal for beginners.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "chest-press-machine",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Chest Supported Machine Row",
                Description = "A seated rowing machine exercise with a chest pad that supports the torso, so the lats and the muscles between the shoulder blades do the pulling and the lower back stays out of it. You pull the handles back by driving the elbows behind you, then let them return forward with control.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "chest-supported-machine-row",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Chin-Ups",
                Description = "A supinated-grip pull-up that strongly activates the biceps alongside the lats.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "chin-ups",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Concentration Curl",
                Description = "An isolation curl performed seated for peak bicep contraction.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "concentration-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Crunches",
                Description = "A basic abdominal exercise focusing on the rectus abdominis.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "crunches",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Bench Press",
                Description = "A compound chest exercise using dumbbells, allowing a greater range of motion than the barbell bench press.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "db-bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Goblet Squat",
                Description = "A beginner-friendly squat with one dumbbell held upright against the chest. The weight in front of you counterbalances your body, so it is easy to sit deep with an upright torso while the quadriceps and glutes do the work.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "db-goblet-squat",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Lunge",
                Description = "A unilateral lower-body exercise with dumbbells targeting quads and glutes through a stepping motion.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "db-lunge",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Preacher Curl",
                Description = "A biceps isolation curl performed with a dumbbell in each hand and the upper arms supported on a preacher bench. The pad locks the elbows in place, so the biceps do the work with almost no swing.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "db-preacher-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dead Hang",
                Description = "A static hang from a pull-up bar with arms fully extended, primarily challenging grip and forearm strength.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "dead-hang",
                TrackingMode = TrackingMode.Duration,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Barbell Deadlift",
                Description = "A full-body compound lift that primarily targets the posterior chain.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "deadlift",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Decline Dumbbell Bench Press",
                Description = "A compound chest press on a decline bench with a dumbbell in each hand, targeting the lower pectorals.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "decline-bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Decline Bench Press",
                Description = "A barbell compound press on a decline bench emphasizing the lower chest.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "decline-bench-press-barbell",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Decline Crunch",
                Description = "A crunch performed on a decline bench, increasing the range of motion and resistance on the abs.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "decline-crunch",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dips",
                Description = "A compound bodyweight exercise targeting the lower chest and triceps.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "dips",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Calf Raise",
                Description = "A weighted calf raise holding dumbbells at the sides, done on the floor or on an elevated edge for a fuller stretch.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "dumbbell-calf-raise",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Shoulder Press",
                Description = "An overhead press with dumbbells performed seated or standing, building the front and side delts.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "dumbbell-shoulder-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Side Bend",
                Description = "A standing oblique isolation exercise using a dumbbell to develop lateral core strength and stability.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "dumbbell-side-bend",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Tricep Extension",
                Description = "An overhead triceps extension with a dumbbell in each hand, both arms working together.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "dumbbell-tricep-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Goblet Squat",
                Description = "A beginner-friendly squat with a kettlebell held at chest height for improved posture and depth.",
                EquipmentType = EquipmentType.Kettlebell,
                AssetId = "goblet-squat",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Hammer Curl",
                Description = "A bicep curl variation with a neutral grip targeting the brachioradialis.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "hammer-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Handstand",
                Description = "A freestanding static hold balanced upside down on the hands with the body stacked in a straight line. It builds shoulder strength, wrist and trunk stability and balance.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "handstand-hold",
                TrackingMode = TrackingMode.Duration,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Hanging Knee Raise",
                Description = "A hanging core exercise on a pull-up bar that targets the lower abs and hip flexors with bent knees.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "hanging-knee-raise",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Hanging Leg Raise",
                Description = "An advanced core exercise performed hanging from a bar.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "hanging-leg-raise",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Hip Abduction",
                Description = "A machine exercise targeting the outer hip muscles.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "hip-abduction",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Hip Adduction",
                Description = "A machine exercise pressing the legs together against resistance, isolating and strengthening the inner-thigh adductors.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "hip-adduction",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Hip Thrust",
                Description = "A compound glute exercise using a barbell across the hips.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "hip-thrust",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Incline Bench Press",
                Description = "A barbell pressing movement on an incline bench targeting the upper chest.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "incline-bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Incline Dumbbell Bench Press",
                Description = "An incline pressing movement emphasizing the upper chest.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "incline-db-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Incline Treadmill Walk",
                Description = "A steady uphill walk on an inclined treadmill belt, keeping one foot in contact with the belt throughout so the glutes and hamstrings work hard with almost no impact.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "incline-treadmill-walk",
                TrackingMode = TrackingMode.Duration,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Kettlebell Russian Twist",
                Description = "A seated rotational core exercise twisting a kettlebell from side to side with the feet lifted.",
                EquipmentType = EquipmentType.Kettlebell,
                AssetId = "kettlebell-russian-twist",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Kettlebell Swing",
                Description = "An explosive hip-hinge movement using a kettlebell for power and conditioning.",
                EquipmentType = EquipmentType.Kettlebell,
                AssetId = "kettlebell-swing",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Lat Pulldown",
                Description = "A cable machine exercise targeting the latissimus dorsi.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "lat-pulldown",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Dumbbell Lateral Raise",
                Description = "An isolation movement targeting the lateral deltoid for shoulder width.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "lateral-raise",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Prone Leg Curl",
                Description = "An isolation exercise for the hamstrings using a leg curl machine.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "leg-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Leg Extension",
                Description = "An isolation exercise for the quadriceps using a machine.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "leg-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Leg Press",
                Description = "A machine-based compound movement for the quads and glutes.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "leg-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Bicep Curl",
                Description = "A machine-based bicep curl for isolated arm training.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "machine-bicep-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Calf Raise",
                Description = "A standing machine exercise isolating the calves through a full stretch and rise onto the toes.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "machine-calf-raise",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Chest Fly",
                Description = "A chest isolation exercise performed on a machine that arcs the handles together in front of the body.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "machine-chest-fly",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Reverse Fly",
                Description = "A seated machine exercise for the rear deltoids, also known as the reverse pec deck: facing the pad, you sweep the two handles out and back in a wide arc against the weight stack. The pad keeps the torso still, so the work stays on the back of the shoulders and the muscles between the shoulder blades.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "machine-reverse-fly",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Shoulder Press",
                Description = "A machine-based overhead pressing movement for the shoulders.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "machine-shoulder-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Machine Triceps Extension",
                Description = "A seated machine isolation exercise in which the upper arms stay supported on a pad while the elbows extend against two handles, loading the triceps along a fixed path without help from the shoulders or torso.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "machine-triceps-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Muscle Ups",
                Description = "An advanced bar movement combining an explosive pull-up with a dip transition to finish above the bar.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "muscle-ups",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "One Arm Dumbbell Preacher Curl",
                Description = "A unilateral biceps curl performed seated at a preacher bench with the upper arm supported on the pad. Training one arm at a time keeps the elbow fixed and isolates the biceps.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "one-arm-dumbbell-preacher-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Overhead Tricep Extension",
                Description = "An isolation exercise for the triceps emphasizing the long head.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "overhead-tricep-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Pistol Squat",
                Description = "A single-leg squat performed with the non-working leg extended forward, demanding strength and balance.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "pistol-squat",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Preacher Curl",
                Description = "A curl variation using a preacher bench to isolate the biceps.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "preacher-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Pull-Up",
                Description = "A bodyweight compound pull targeting the lats and biceps.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "pull-up",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Push-Up",
                Description = "A fundamental bodyweight exercise for the chest, shoulders, and triceps.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "push-up",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Romanian Deadlift",
                Description = "A hip-hinge movement emphasizing the hamstrings and glutes.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "romanian-deadlift",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Rowing Machine",
                Description = "A full-body cardio machine movement in which each stroke drives with the legs, swings the torso back and pulls the handle to the ribs, training the legs, back and arms in one continuous cycle.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "rowing-machine",
                TrackingMode = TrackingMode.Duration,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Russian Twist",
                Description = "A rotational core exercise targeting the obliques.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "russian-twist",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Seated Cable Row",
                Description = "A back exercise performed on a cable row machine, pulling a handle toward the torso while seated.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "seated-cable-row",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Seated Dumbbell Shoulder Press",
                Description = "A seated pressing movement for the shoulders using dumbbells.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "seated-db-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Seated Dip Machine",
                Description = "A selectorized machine version of the dip: seated upright with your back against the pad, you press two lever arms down by your sides until your arms are straight. The movement follows the path of a bodyweight dip, but the load is the weight you select on the stack, and the seat takes your body weight.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "seated-dip-machine",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Seated Leg Curl",
                Description = "A machine isolation exercise for the hamstrings performed in a seated position, providing consistent tension and reduced hip flexor involvement compared to the lying variant.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "seated-leg-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Single-Arm Dumbbell Row",
                Description = "A unilateral back exercise using a dumbbell for balanced development.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "single-arm-db-row",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Single-Arm Dumbbell Overhead Tricep Extension",
                Description = "A one-arm overhead tricep extension giving a long, unilateral stretch of the long head and training anti-side-bend core stability.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "single-arm-dumbbell-overhead-tricep-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Single Leg Extension",
                Description = "A quadriceps isolation exercise performed on a leg extension machine, working one leg at a time.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "single-leg-extension",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Single Leg Press",
                Description = "A lower-body exercise performed on a leg press machine, pressing the platform with one leg at a time.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "single-leg-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Sit-Ups",
                Description = "A classic abdominal exercise with a full range of motion.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "sit-ups",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Bench Press",
                Description = "A bench press variation in the Smith machine, where the guided bar path adds stability for the chest.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Bulgarian Split Squat",
                Description = "A Bulgarian split squat performed in a Smith machine for added stability and load control.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-bulgarian-split",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Decline Bench Press",
                Description = "A bench press on a decline bench under the Smith machine, where the head-down angle and the guided bar path put the work on the lower chest.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-decline-bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Hip Thrust",
                Description = "A hip thrust with the bar running in the Smith machine guides, so the load travels in a fixed vertical line across the hips while the shoulders stay supported on a bench.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-hip-thrust",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Incline Bench Press",
                Description = "An incline press in the Smith machine, guiding the bar to target the upper chest and front delts.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-incline-bench-press",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Romanian Deadlift",
                Description = "A Romanian deadlift performed on a Smith machine, fixing the bar path so you can focus on the hip hinge and posterior-chain stretch.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-rdl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Smith Machine Squat",
                Description = "A squat performed on the Smith machine, using the fixed bar path for added stability while training quads and glutes.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "smith-machine-squat",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Spider Curl",
                Description = "A curl lying face-down on an incline bench with arms hanging vertical, isolating the biceps through a strict range.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "spider-curl",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Barbell Squat",
                Description = "A compound lower-body movement targeting the quadriceps, glutes, and hamstrings.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "squat",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Stair Climber",
                Description = "A cardio machine movement that climbs a revolving staircase step after step, loading the glutes and quads continuously with no landing impact.",
                EquipmentType = EquipmentType.Machine,
                AssetId = "stair-climber",
                TrackingMode = TrackingMode.Duration,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Sumo Squat",
                Description = "A barbell squat performed with a wide stance and turned-out toes, emphasizing the glutes and quads.",
                EquipmentType = EquipmentType.Barbell,
                AssetId = "sumo-squat",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Tricep Kickback",
                Description = "An isolation exercise for the triceps performed in a bent-over position with a dumbbell in each hand.",
                EquipmentType = EquipmentType.Dumbbell,
                AssetId = "tricep-kickback",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Cable Tricep Pushdown",
                Description = "An isolation exercise targeting the triceps using a cable machine.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "tricep-pushdown",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "V-Bar Tricep Pushdown",
                Description = "A cable tricep pushdown using a V-handle, which locks the wrists in a pronated, slightly-angled position and loads the lateral head.",
                EquipmentType = EquipmentType.Cable,
                AssetId = "v-bar-tricep-pushdown",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "V Ups",
                Description = "A dynamic core exercise raising the legs and torso together into a V shape, training the abs and hip flexors.",
                EquipmentType = EquipmentType.Bodyweight,
                AssetId = "v-ups",
                TrackingMode = TrackingMode.Reps,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Weighted Dips",
                Description = "A parallel-bar dip performed with extra load — most often a plate hung from a dip belt between the legs — to keep the movement in a strength rep range once bodyweight dips are easy.",
                EquipmentType = EquipmentType.Other,
                AssetId = "weighted-dips",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
            new Exercise
            {
                Name = "Weighted Pull-Up",
                Description = "A pull-up performed with extra load — most often a plate hung from a dip belt between the legs — to keep the movement in a strength rep range once bodyweight pull-ups are easy.",
                EquipmentType = EquipmentType.Other,
                AssetId = "weighted-pull-up",
                TrackingMode = TrackingMode.RepsAndWeight,
                IsBuiltIn = true
            },
    ];
}