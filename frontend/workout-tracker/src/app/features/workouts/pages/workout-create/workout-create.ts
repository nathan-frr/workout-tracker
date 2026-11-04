import { Component, inject } from '@angular/core';
import { FormBuilder,Validators, ReactiveFormsModule} from '@angular/forms';
import { ExercisesStore } from '../../../exercises/data-access/exercises.store';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'workout-create',
  styleUrl: './workout-create.scss',
  templateUrl: './workout-create.html',
})
export class WorkoutCreate {
  exercisesStore = inject(ExercisesStore);
  
  readonly exercises = this.exercisesStore.exercises;
  readonly loading = this.exercisesStore.loading;
  readonly error = this.exercisesStore.error;

  ngOnInit(): void {
    this.exercisesStore.loadExercises();
  }
}
