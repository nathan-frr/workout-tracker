import { Injectable, inject, signal } from '@angular/core';
import { finalize, Observable, tap } from 'rxjs';
import { Exercise } from '../models/exercise.model';
import { ExerciseService } from './exercises-api.service';
import { CreateExerciseRequest } from '../models/create-exercise-request.model';

@Injectable({
  providedIn: 'root'
})
export class ExercisesStore {
  private api = inject(ExerciseService);

  private _exercises = signal<Exercise[]>([]);
  private _loading = signal(false);
  private _error = signal<string | null>(null);
  private _loaded = signal(false);

  // Public read-only state
  exercises = this._exercises.asReadonly();
  loading = this._loading.asReadonly();
  error = this._error.asReadonly();

  loadExercises(): void {
    // Avoid fetching again if the library has already been loaded.
    if (this._loaded() || this._loading()) {
      return;
    }

    this._loading.set(true);
    this._error.set(null);

    this.api.getExercises()
      .pipe(
        finalize(() => this._loading.set(false))
      )
      .subscribe({
        next: exercises => {
          this._exercises.set(exercises);
          this._loaded.set(true);
        },
        error: () => {
          this._error.set('Failed to load exercises.');
        }
      });
  }

  refreshExercises(): void {
    this._loaded.set(false);
    this.loadExercises();
  }

  createExercise(request: CreateExerciseRequest): Observable<Exercise> {
    return this.api.createExercise(request).pipe(
        tap(exercise => {
            this._exercises.update(current => [...current, exercise]);
        })
    );
    }
}