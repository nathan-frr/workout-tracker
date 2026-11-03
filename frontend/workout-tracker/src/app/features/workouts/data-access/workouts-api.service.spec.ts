
import {
  HttpTestingController,
  provideHttpClientTesting,
} from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { WorkoutService } from './workouts-api.service';
import { EquipmentType } from '../../exercises/models/equipment-type';
import { TrackingMode } from '../../exercises/models/tracking-mode';
import { WorkoutType } from '../models/workout-type';

describe('WorkoutService', () => {
  let service: WorkoutService;
  let httpTesting: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        WorkoutService,
        provideHttpClient(),
        provideHttpClientTesting(),
      ],
    });

    service = TestBed.inject(WorkoutService);
    httpTesting = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTesting.verify();
  });

  it('should get workouts from the API', () => {
    const response = [
      {
        id: 'workout-id',
        userId: 'user-id',
        title: 'Push Workout',
        workoutDate: '2026-11-02',
        startedAtTime: '2026-11-02T09:30:00+01:00',
        durationInMinutes: 52,
        location: 'Copenhagen',
        workoutType: WorkoutType.Push,
        notes: null,
        createdAt: '2026-11-02T10:30:00+01:00',
        exercises: [
          {
            id: 'workout-exercise-id',
            exercise: {
              id: 'exercise-id',
              name: 'Bench Press',
              mediaUrl: null,
              equipmentType: EquipmentType.Barbell,
              trackingMode: TrackingMode.RepsAndWeight,
            },
            order: 1,
            sets: [
              {
                id: 'set-id',
                setNumber: 1,
                reps: 12,
                weight: 50,
                durationInSeconds: null,
                distanceInMeters: null,
                isCompleted: true,
                notes: null,
              },
            ],
          },
        ],
      },
    ];

    service.getWorkouts().subscribe((workouts) => {
      expect(workouts).toEqual(response);
    });

    const request = httpTesting.expectOne('/api/workouts');

    expect(request.request.method).toBe('GET');

    request.flush(response);
  });

    it('should get workouts from the API', () => {
    const response = {
        id: 'workout-id',
        userId: 'user-id',
        title: 'Push Workout',
        workoutDate: '2026-11-02',
        startedAtTime: '2026-11-02T09:30:00+01:00',
        durationInMinutes: 52,
        location: 'Copenhagen',
        workoutType: WorkoutType.Push,
        notes: null,
        createdAt: '2026-11-02T10:30:00+01:00',
        exercises: [
          {
            id: 'workout-exercise-id',
            exercise: {
              id: 'exercise-id',
              name: 'Bench Press',
              mediaUrl: null,
              equipmentType: EquipmentType.Barbell,
              trackingMode: TrackingMode.RepsAndWeight,
            },
            order: 1,
            sets: [
              {
                id: 'set-id',
                setNumber: 1,
                reps: 12,
                weight: 50,
                durationInSeconds: null,
                distanceInMeters: null,
                isCompleted: true,
                notes: null,
              },
            ],
          },
        ],
      };

    service.getWorkoutById('workout-id').subscribe((workout) => {
      expect(workout).toEqual(response);
    });

    const request = httpTesting.expectOne('/api/workouts/workout-id');

    expect(request.request.method).toBe('GET');

    request.flush(response);
  });
});
