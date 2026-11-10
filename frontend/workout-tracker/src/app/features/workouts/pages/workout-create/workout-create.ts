import { Component, computed, inject, signal } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule, FormArray } from '@angular/forms';
import { ExercisesStore } from '../../../exercises/data-access/exercises.store';
import { WorkoutExerciseEditor } from '../workout-exercise-editor/workout-exercise-editor';
import { WorkoutType } from '../../models/workout-type';
import { Exercise } from '../../../exercises/models/exercise.model';
import { WorkoutService } from '../../data-access/workouts-api.service';
import { CreateWorkoutRequest } from '../../models/create-workout-request.model';
import { SetForm, WorkoutExerciseForm, WorkoutForm } from '../../models/workout-form';

@Component({
  imports: [ReactiveFormsModule, WorkoutExerciseEditor],
  selector: 'workout-create',
  styleUrl: './workout-create.scss',
  templateUrl: './workout-create.html',
})
export class WorkoutCreate {
  exercisesStore = inject(ExercisesStore);
  workoutService = inject(WorkoutService);

  private fb = inject(FormBuilder);
  
  readonly fetchedExercises = this.exercisesStore.exercises;
  readonly loading = this.exercisesStore.loading;
  readonly error = this.exercisesStore.error;
  
  workoutTypes = Object.values(WorkoutType);

  workoutForm: WorkoutForm = this.fb.group({
    title: this.fb.nonNullable.control('', Validators.required),
    workoutDate: this.fb.nonNullable.control(new Date().toISOString().slice(0, 10), Validators.required),
    durationInMinutes: this.fb.control<number | null>(null),
    location: this.fb.control<string | null>(null),
    workoutType: this.fb.nonNullable.control(WorkoutType.Other),
    notes: this.fb.control<string | null>(null),
    startedAtTime: this.fb.control<string | null>(null),
    exercises: new FormArray<WorkoutExerciseForm>([], Validators.required)
  });

  searchTerm = signal('');

  filteredExercises = computed(() => {
    const query = this.searchTerm().toLowerCase();

    return query.length ? this.fetchedExercises().filter(e =>
      e.name.toLowerCase().includes(query)
    ) : [];
  });

  ngOnInit(): void {
    this.exercisesStore.loadExercises();
  }

  addExercise(exercise: Exercise): void {
    const exerciseForm: WorkoutExerciseForm = this.fb.group({
      exerciseId: this.fb.nonNullable.control(exercise.id, Validators.required),
      order: this.fb.nonNullable.control(this.exercises.length + 1),
      sets: new FormArray<SetForm>([], Validators.required),
    });

    this.exercises.push(exerciseForm);
  }

  selectWorkoutType(type: WorkoutType): void {
    this.workoutForm.controls.workoutType.setValue(type);
  }

  get exercises(): FormArray<WorkoutExerciseForm> {
    return this.workoutForm.controls.exercises;
  }

  getExercise(form: WorkoutExerciseForm): Exercise {
    const id = form.controls.exerciseId.value;

    return this.fetchedExercises().find(
      exercise => exercise.id === id
    )!;
  }

  saveWorkout(): void {
    if (this.workoutForm.invalid) {
      this.workoutForm.markAllAsTouched();
      return;
    }
    const request: CreateWorkoutRequest = this.workoutForm.getRawValue();

    this.workoutService.createWorkout(request).subscribe({
      next: workoutSession => {
        console.log("Workout registered", workoutSession) 
      },
      error: (e) => {
        console.log("Error", e)
      }
    })
  }

  log() {
    console.log(this.workoutForm.getRawValue())
  }
}
