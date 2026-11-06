import { FormArray, FormControl, FormGroup } from "@angular/forms";
import { WorkoutType } from "./workout-type";

export type WorkoutForm = FormGroup<{
    title: FormControl<string>;
    workoutDate: FormControl<string>;
    durationInMinutes: FormControl<number | null>;
    location: FormControl<string | null>;
    workoutType: FormControl<WorkoutType>;
    notes: FormControl<string | null>;
    startedAtTime: FormControl<string | null>;
    exercises: FormArray<WorkoutExerciseForm>;
}>;

export type WorkoutExerciseForm = FormGroup<{
    exerciseId: FormControl<string>;
    order: FormControl<number>;
    sets: FormArray<SetForm>;
}>;

export type SetForm = FormGroup<{
    setNumber: FormControl<number>;
    reps: FormControl<number | null>;
    weight: FormControl<number | null>;
    durationInSeconds: FormControl<number | null>;
    distanceInMeters: FormControl<number | null>;
    isCompleted: FormControl<boolean>;
    notes: FormControl<string | null>;
}>;