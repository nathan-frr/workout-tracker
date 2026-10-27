import { Observable, of } from 'rxjs';
import { Exercise } from '../models/exercise.model';

export const mockExercises: Exercise[] = [
  {
    id: '00000000-0000-0000-0000-000000000001',
    name: 'Bench Press',
    description: 'Barbell chest press.',
    equipmentType: 1,
    mediaUrl: null,
    trackingMode: 0,
    isBuiltIn: true,
    muscleGroups: [
      { id: 1, name: 'Chest', role: 'Primary' },
    ],
  },
  {
    id: '00000000-0000-0000-0000-000000000002',
    name: 'Bodyweight Squat',
    description: 'Squat using bodyweight resistance.',
    equipmentType: 0,
    mediaUrl: null,
    trackingMode: 0,
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
}