export interface ExerciseMuscleGroup {
  id: number;
  name: string;
  role: string;
}

export interface Exercise {
  id: string;
  name: string;
  description: string | null;
  equipmentType: number;
  mediaUrl: string | null;
  trackingMode: number;
  isBuiltIn: boolean;
  muscleGroups: ExerciseMuscleGroup[];
}