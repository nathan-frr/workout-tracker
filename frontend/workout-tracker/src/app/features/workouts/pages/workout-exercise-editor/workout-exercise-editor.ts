import { Component, inject, input, OnInit } from '@angular/core';
import { FormBuilder,Validators, ReactiveFormsModule, FormGroup, FormControl, FormArray} from '@angular/forms';
import { Exercise } from '../../../exercises/models/exercise.model';
import { TRACKING_MODE_FIELDS, TrackingField } from '../../../exercises/models/tracking-mode';


@Component({
  imports: [ReactiveFormsModule],
  selector: 'workout-exercise-editor',
  styleUrl: './workout-exercise-editor.scss',
  templateUrl: './workout-exercise-editor.html',
})
export class WorkoutExerciseEditor {
  exercise = input.required<Exercise>();
  exerciseForm = input.required<FormGroup>();

  private fb = inject(FormBuilder);

  get sets(): FormArray {
    return this.exerciseForm().get('sets') as FormArray;
  }

  get metrics(): TrackingField[] {
    return TRACKING_MODE_FIELDS[this.exercise().trackingMode];
  }

  addSet(): void {
    this.sets.push(this.createSetForm());
  }

  createSetForm(): FormGroup {
    const fields = TRACKING_MODE_FIELDS[this.exercise().trackingMode];

    const controls = Object.fromEntries(
      fields.map(field => [
        field,
        this.fb.control<number | null>(
          null,
          [Validators.required, Validators.min(0)]
        )
      ])
    );

    return this.fb.group({
      setNumber: this.fb.control(this.sets.length + 1, [Validators.required, Validators.min(1)]),
      ...controls,
    });
  }
}
