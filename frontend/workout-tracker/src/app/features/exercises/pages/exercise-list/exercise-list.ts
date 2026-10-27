import { Component, inject, signal } from '@angular/core';
import { ExerciseService } from '../../data-access/exercises-api.service';
import { Exercise } from '../../models/exercise.model';

@Component({
  selector: 'exercise-list',
  standalone: true,
  templateUrl: './exercise-list.html',
  styleUrl: './exercise-list.scss',
})
export class ExerciseListComponent {
  private readonly exerciseService = inject(ExerciseService);
  readonly exercises = signal<Exercise[]>([]);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  constructor() {
    this.loadExercises();
  }

  loadExercises(): void {
    this.loading.set(true);
    this.error.set(null);

    this.exerciseService.getExercises().subscribe({
      next: (exercises) => {
        this.exercises.set(exercises);
        this.loading.set(false);
      },
      error: () => {
        this.error.set('Could not load exercises. Please try again.');
        this.loading.set(false);
      },
    });
  }
}