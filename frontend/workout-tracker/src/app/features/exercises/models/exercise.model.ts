import { EquipmentType } from "./equipment-type";
import { TrackingMode } from "./tracking-mode";

export interface ExerciseMuscleGroup {
  id: number;
  name: string;
  role: string;
}

export interface Exercise {
  id: string;
  name: string;
  description: string | null;
  equipmentType: EquipmentType;
  mediaUrl: string | null;
  trackingMode: TrackingMode;
  isBuiltIn: boolean;
  muscleGroups: ExerciseMuscleGroup[];
}