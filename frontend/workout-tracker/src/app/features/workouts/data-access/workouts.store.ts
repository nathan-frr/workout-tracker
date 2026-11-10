import { Injectable, inject, signal } from '@angular/core';
import { finalize, Observable, tap } from 'rxjs';
import { WorkoutService } from './workouts-api.service';
import { WorkoutSession } from '../models/workout-session.model';
import { CreateWorkoutRequest } from '../models/create-workout-request.model';

@Injectable({
  providedIn: 'root'
})
export class WorkoutsStore {
  private api = inject(WorkoutService);

  private _workouts = signal<WorkoutSession[]>([]);
  private _loading = signal(false);
  private _error = signal<string | null>(null);
  private _loaded = signal(false);

  // Public read-only state
  workouts = this._workouts.asReadonly();
  loading = this._loading.asReadonly();
  error = this._error.asReadonly();

  loadWorkouts(): void {
    // Avoid fetching again if the library has already been loaded.
    if (this._loaded() || this._loading()) {
      return;
    }

    this._loading.set(true);
    this._error.set(null);

    this.api.getWorkouts()
      .pipe(
        finalize(() => this._loading.set(false))
      )
      .subscribe({
        next: workouts => {
          this._workouts.set(workouts);
          this._loaded.set(true);
        },
        error: () => {
          this._error.set('Failed to load workouts.');
        }
      });
  }

  refreshWorkouts(): void {
    this._loaded.set(false);
    this.loadWorkouts();
  }

  createWorkout(request: CreateWorkoutRequest): Observable<WorkoutSession> {
    return this.api.createWorkout(request).pipe(
        tap(exercise => {
            this._workouts.update(current => [...current, exercise]);
        })
    );
    }
}