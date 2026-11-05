import { Component, inject } from '@angular/core';
import { FormBuilder,Validators, ReactiveFormsModule, FormGroup, FormArray} from '@angular/forms';
import { ExercisesStore } from '../../../exercises/data-access/exercises.store';
import { WorkoutExerciseEditor } from '../workout-exercise-editor/workout-exercise-editor';
import { WorkoutType } from '../../models/workout-type';
import { Exercise } from '../../../exercises/models/exercise.model';

@Component({
  imports: [ReactiveFormsModule, WorkoutExerciseEditor],
  selector: 'workout-create',
  styleUrl: './workout-create.scss',
  templateUrl: './workout-create.html',
})
export class WorkoutCreate {
  exercisesStore = inject(ExercisesStore);

  private fb = inject(FormBuilder);
  
  readonly fetchedExercises = this.exercisesStore.exercises;
  readonly loading = this.exercisesStore.loading;
  readonly error = this.exercisesStore.error;
  
  workoutTypes = Object.values(WorkoutType);

  workoutForm = this.fb.group({
    title: ['', Validators.required],
    workoutDate: [new Date().toISOString().slice(0, 10), Validators.required],
    durationInMinutes: [''],
    location: [''],
    WorkoutType: [WorkoutType.Other],
    notes: [''],
    exercises: this.fb.array<FormGroup>([])
  })

  ngOnInit(): void {
    this.exercisesStore.loadExercises();
  }

  addExercise(exercise: Exercise): void {
    const exerciseForm = this.fb.group({
      exerciseId: [exercise.id, Validators.required],
      notes: [''],
      sets: this.fb.array<FormGroup>([])
    });

    this.exercises.push(exerciseForm);
  }

  selectWorkoutType(type: WorkoutType): void {
    this.workoutForm.controls.WorkoutType.setValue(type);
  }

  get exercises(): FormArray<FormGroup> {
    return this.workoutForm.controls.exercises;
  }

  getExercise(form: FormGroup): Exercise {
    const id = form.get('exerciseId')?.value;

    return this.fetchedExercises().find(
      exercise => exercise.id === id
    )!;
  }

}
