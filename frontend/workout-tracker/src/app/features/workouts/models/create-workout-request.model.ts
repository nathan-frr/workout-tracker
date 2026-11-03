import { WorkoutType } from "./workout-type";

export interface CreateSetEntryRequest {
  setNumber: number;
  reps: number | null;
  weight: number | null;
  durationInSeconds: number | null;
  distanceInMeters: number | null;
  isCompleted: boolean;
  notes: string | null;
}

export interface CreateWorkoutExerciseRequest {
  exerciseId: string;
  order: number;
  sets: CreateSetEntryRequest[];
}

export interface CreateWorkoutRequest {
  title: string;
  workoutDate: string;
  startedAtTime: string | null;
  durationInMinutes: number | null;
  location: string | null;
  workoutType: WorkoutType | null;
  notes: string | null;
  exercises: CreateWorkoutExerciseRequest[];
}