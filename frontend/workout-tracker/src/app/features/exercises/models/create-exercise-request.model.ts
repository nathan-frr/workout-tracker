import { EquipmentType } from "./equipment-type";
import { TrackingMode } from "./tracking-mode";

export interface CreateExerciseMuscleGroupRequest {
  muscleGroupId: number;
  role: string;
}

export interface CreateExerciseRequest {
  name: string;
  description: string | null;
  equipmentType: EquipmentType;
  mediaUrl: string | null;
  trackingMode: TrackingMode;
  muscleGroups: CreateExerciseMuscleGroupRequest[];
}