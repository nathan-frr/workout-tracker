import { Observable, of, throwError } from 'rxjs';
import { Exercise } from '../models/exercise.model';
import { EquipmentType } from '../models/equipment-type';
import { TrackingMode } from '../models/tracking-mode';
import { CreateExerciseRequest } from '../models/create-exercise-request.model';

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

export const mockExerciseRequest: CreateExerciseRequest = {
    name: 'Bench Press',
    description: 'Barbell chest press.',
    equipmentType: EquipmentType.Barbell,
    mediaUrl: null,
    trackingMode: TrackingMode.RepsAndWeight,
    muscleGroups: [
      { muscleGroupId: 1, role: 'Primary' },
    ],
};

export const mockMuscleGroups = [
  { id: 1, name: 'Chest' },
  { id: 2, name: 'Quadriceps' },
  { id: 3, name: 'Back' },
];

export class MockExercisesApiService {
  getExercises(): Observable<Exercise[]> {
    return of(structuredClone(mockExercises));
  }

  getExerciseById(id: string): Observable<Exercise> {
    const exercise = mockExercises.find(exercise => exercise.id === id);

    if (!exercise) {
      return throwError(() => new Error('Exercise not found'));
    }

    return of(structuredClone(exercise));
  }

  createExercise(request: CreateExerciseRequest): Observable<Exercise> {
    const newExercise: Exercise = {
      id: crypto.randomUUID(),
      name: request.name,
      description: request.description,
      equipmentType: request.equipmentType,
      mediaUrl: request.mediaUrl,
      trackingMode: request.trackingMode,
      isBuiltIn: false,
      muscleGroups: request.muscleGroups.map(group => ({
        id: group.muscleGroupId,
        name: mockMuscleGroups.find(m => m.id === group.muscleGroupId)?.name ?? 'Unknown',
        role: group.role
      }))
    };

    mockExercises.push(newExercise);

    return of(structuredClone(newExercise));
  }
}