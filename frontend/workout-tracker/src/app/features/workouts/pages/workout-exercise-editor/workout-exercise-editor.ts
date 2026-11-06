import { Component, inject, input, OnInit } from '@angular/core';
import { FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { Exercise } from '../../../exercises/models/exercise.model';
import { TRACKING_MODE_FIELDS, TrackingField } from '../../../exercises/models/tracking-mode';
import { SetForm, WorkoutExerciseForm } from '../../models/workout-form';


@Component({
  imports: [ReactiveFormsModule],
  selector: 'workout-exercise-editor',
  styleUrl: './workout-exercise-editor.scss',
  templateUrl: './workout-exercise-editor.html',
})
export class WorkoutExerciseEditor {
  exercise = input.required<Exercise>();
  exerciseForm = input.required<WorkoutExerciseForm>();

  private fb = inject(FormBuilder);

  get sets(): WorkoutExerciseForm['controls']['sets'] {
    return this.exerciseForm().controls.sets;
  }

  get metrics(): TrackingField[] {
    return TRACKING_MODE_FIELDS[this.exercise().trackingMode];
  }

  addSet(): void {
    this.sets.push(this.createSetForm());
  }

  createSetForm(): SetForm {
    const fields = TRACKING_MODE_FIELDS[this.exercise().trackingMode];
    const validatorsFor = (field: TrackingField) => fields.includes(field)
      ? [Validators.required, Validators.min(0)]
      : [];

    return this.fb.group({
      setNumber: this.fb.nonNullable.control(this.sets.length + 1, [Validators.required, Validators.min(1)]),
      reps: this.fb.control<number | null>(null, validatorsFor('reps')),
      weight: this.fb.control<number | null>(null, validatorsFor('weight')),
      durationInSeconds: this.fb.control<number | null>(null, validatorsFor('durationInSeconds')),
      distanceInMeters: this.fb.control<number | null>(null, validatorsFor('distanceInMeters')),
      isCompleted: this.fb.nonNullable.control(true),
      notes: this.fb.control<string | null>(null),
    });
  }
}
