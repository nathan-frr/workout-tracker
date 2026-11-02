import { Observable, of } from 'rxjs';
import { WorkoutSession } from '../models/workout-session.model';
import { WorkoutType } from '../models/workout-type';
import { EquipmentType } from '../../exercises/models/equipment-type';
import { TrackingMode } from '../../exercises/models/tracking-mode';

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
    return of(mockWorkouts);
  }
}