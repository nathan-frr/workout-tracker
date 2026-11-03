import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkoutSession } from '../models/workout-session.model';

@Injectable({ providedIn: 'root' })
export class WorkoutService {
  private readonly http = inject(HttpClient);

  getWorkouts(): Observable<WorkoutSession[]> {
    return this.http.get<WorkoutSession[]>('/api/workouts');
  }
  
  getWorkoutById(id: string): Observable<WorkoutSession> {
    return this.http.get<WorkoutSession>(`/api/workouts/${id}`);
  }
}