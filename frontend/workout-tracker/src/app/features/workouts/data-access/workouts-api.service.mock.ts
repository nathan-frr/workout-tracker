import { Observable, of, throwError } from 'rxjs';
import { WorkoutSession } from '../models/workout-session.model';
import { WorkoutType } from '../models/workout-type';
import { EquipmentType } from '../../exercises/models/equipment-type';
import { TrackingMode } from '../../exercises/models/tracking-mode';
import { CreateWorkoutRequest } from '../models/create-workout-request.model';

export const mockWorkouts: WorkoutSession[] = [
  {
    id: '00000000-0000-0000-0000-000000000001',
    userId: '00002-2555',
    title: 'Afternoon Workout',
    workoutDate: '2026-11-02',
    startedAtTime: '2026-11-02T09:30:00+01:00',
    durationInMinutes: 52,
    location: 'Copenhagen',
    workoutType: WorkoutType.Abs,
    notes: null,
    createdAt: '2026-11-02T10:30:00+01:00',
    exercises: [
      {
        id: '00000000-0000-0000-0000-00000000028',
        exercise: {
          id: '00000000-0000-0000-0000-00000000025',
          name: 'Bench Press',
          mediaUrl: null ,
          equipmentType: EquipmentType.Barbell,
          trackingMode: TrackingMode.RepsAndWeight
        },
        order: 1,
        sets: [
          {
            id: '00025988',
            setNumber: 1,
            reps: 12,
            weight: 50,
            durationInSeconds: null,
            distanceInMeters: null,
            isCompleted: true,
            notes: null,
          }
        ]
      },
    ]
  },
];

export class MockWorkoutsApiService {
  getWorkouts(): Observable<WorkoutSession[]> {
    return of(structuredClone(mockWorkouts));
  }
  
  getWorkoutById(id: string): Observable<WorkoutSession> {
      const workout = mockWorkouts.find(workout => workout.id === id);
  
      if (!workout) {
        return throwError(() => new Error('Workout not found'));
      }
  
      return of(structuredClone(workout));
  }
  
  createWorkout(request: CreateWorkoutRequest): Observable<WorkoutSession> {
    const newWorkout: WorkoutSession = {
      id: crypto.randomUUID(),
      userId: '00002-2555',
      title: request.title,
      workoutDate: request.workoutDate,
      startedAtTime: request.startedAtTime,
      durationInMinutes: request.durationInMinutes,
      location: request.location,
      workoutType: request.workoutType,
      notes: request.notes,
      createdAt: new Date().toISOString(),
      exercises: request.exercises.map(workoutExercise => ({
        id: crypto.randomUUID(),
        exercise: {
          id: workoutExercise.exerciseId,
          name: 'Bench Press',
          mediaUrl: null,
          equipmentType: EquipmentType.Barbell,
          trackingMode: TrackingMode.RepsAndWeight,
        },
        order: workoutExercise.order,
        sets: workoutExercise.sets.map(set => ({
          id: crypto.randomUUID(),
          ...set,
        })),
      })),
    };

    mockWorkouts.push(newWorkout);

    return of(structuredClone(newWorkout));
  }
}