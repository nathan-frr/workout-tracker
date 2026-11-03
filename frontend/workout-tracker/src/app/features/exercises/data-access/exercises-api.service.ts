import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Exercise } from '../models/exercise.model';
import { CreateExerciseRequest } from '../models/create-exercise-request.model';

@Injectable({ providedIn: 'root' })
export class ExerciseService {
  private readonly http = inject(HttpClient);

  getExercises(): Observable<Exercise[]> {
    return this.http.get<Exercise[]>('/api/exercises');
  }

  getExerciseById(id: string): Observable<Exercise> {
    return this.http.get<Exercise>(`/api/exercises/${id}`);
  }

  createExercise(request: CreateExerciseRequest): Observable<Exercise> {
    return this.http.post<Exercise>('/api/exercises', request);
  }
}