import { isPlatformBrowser } from '@angular/common';
import { Component, inject, PLATFORM_ID, signal } from '@angular/core';
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
  private readonly platformId = inject(PLATFORM_ID);

  readonly exercises = signal<Exercise[]>([]);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  constructor() {
    if (isPlatformBrowser(this.platformId)) {
      this.loadExercises();
    }
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