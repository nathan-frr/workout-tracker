import { Component, inject, OnInit, signal } from '@angular/core';
import { ExercisesStore } from '../../data-access/exercises.store';

@Component({
  selector: 'exercise-list',
  imports: [],
  templateUrl: './exercise-list.html',
  styleUrl: './exercise-list.scss',
})
export class ExerciseListComponent implements OnInit {
  exercisesStore = inject(ExercisesStore);
  
  readonly exercises = this.exercisesStore.exercises;
  readonly loading = this.exercisesStore.loading;
  readonly error = this.exercisesStore.error;

  ngOnInit(): void {
    this.exercisesStore.loadExercises();
  }

  constructor() {}
}