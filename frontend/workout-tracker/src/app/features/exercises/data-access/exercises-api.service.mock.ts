import { Observable, of } from 'rxjs';
import { Exercise } from '../models/exercise.model';
import { EquipmentType } from '../models/equipment-type';
import { TrackingMode } from '../models/tracking-mode';

export const mockExercises: Exercise[] = [
  {
    id: '00000000-0000-0000-0000-000000000001',
    name: 'Bench Press',
    description: 'Barbell chest press.',
    equipmentType: EquipmentType.Barbell,
    mediaUrl: null,
    trackingMode: TrackingMode.RepsAndWeight,
    isBuiltIn: true,
    muscleGroups: [
      { id: 1, name: 'Chest', role: 'Primary' },
    ],
  },
  {
    id: '00000000-0000-0000-0000-000000000002',
    name: 'Bodyweight Squat',
    description: 'Squat using bodyweight resistance.',
    equipmentType: EquipmentType.Bodyweight,
    mediaUrl: null,
    trackingMode: TrackingMode.Reps,
    isBuiltIn: true,
    muscleGroups: [
      { id: 2, name: 'Quadriceps', role: 'Primary' },
    ],
  },
];

export class MockExercisesApiService {
  getExercises(): Observable<Exercise[]> {
    return of(mockExercises);
  }

  getExerciseById(): Observable<Exercise> {
    return of(mockExercises[0]);
  }
}