import { EquipmentType } from "../../exercises/models/equipment-type";
import { TrackingMode } from "../../exercises/models/tracking-mode";
import { WorkoutType } from "./workout-type";

export interface WorkoutExercise {
  id: string;
  exercise: ExerciseSummary;
  order: number;
  sets: SetEntry[];
}

export interface ExerciseSummary {
  id: string;
  name: string;
  mediaUrl: string | null;
  equipmentType: EquipmentType;
  trackingMode: TrackingMode;
}

export interface SetEntry {
  id: string;
  setNumber: number;
  reps: number | null;
  weight: number | null;
  durationInSeconds: number | null;
  distanceInMeters: number | null;
  isCompleted: boolean;
  notes: string | null;
}

export interface WorkoutSession {
  id: string;
  userId: string;
  title: string;
  workoutDate: string;
  startedAtTime: string | null;
  durationInMinutes: number | null;
  location: string | null;
  workoutType: WorkoutType | null;
  notes: string | null;
  createdAt: string;
  exercises: WorkoutExercise[];
}