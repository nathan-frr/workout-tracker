
import {
  HttpTestingController,
  provideHttpClientTesting,
} from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { ExerciseService } from './exercises-api.service';
import { EquipmentType } from '../models/equipment-type';
import { TrackingMode } from '../models/tracking-mode';

describe('ExerciseService', () => {
  let service: ExerciseService;
  let httpTesting: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        ExerciseService,
        provideHttpClient(),
        provideHttpClientTesting(),
      ],
    });

    service = TestBed.inject(ExerciseService);
    httpTesting = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTesting.verify();
  });

  it('should get exercises from the API', () => {
    const response = [
      {
        id: 'exercise-id',
        name: 'Bench Press',
        description: null,
        equipmentType: EquipmentType.Barbell,
        mediaUrl: null,
        trackingMode: TrackingMode.RepsAndWeight,
        isBuiltIn: true,
        muscleGroups: [],
      },
    ];

    service.getExercises().subscribe((exercises) => {
      expect(exercises).toEqual(response);
    });

    const request = httpTesting.expectOne('/api/exercises');

    expect(request.request.method).toBe('GET');

    request.flush(response);
  });

  it('should get one specific exercise from the API', () => {
    const response = 
      {
        id: 'exercise-id',
        name: 'Bench Press',
        description: null,
        equipmentType: EquipmentType.Barbell,
        mediaUrl: null,
        trackingMode: TrackingMode.RepsAndWeight,
        isBuiltIn: true,
        muscleGroups: [],
      };

    service.getExerciseById('exercise-id').subscribe((exercise) => {
      expect(exercise).toEqual(response);
    });

    const request = httpTesting.expectOne('/api/exercises/exercise-id');

    expect(request.request.method).toBe('GET');

    request.flush(response);
  });
});
