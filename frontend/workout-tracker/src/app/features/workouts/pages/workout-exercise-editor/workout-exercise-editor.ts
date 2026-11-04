import { Component, inject, input, OnInit } from '@angular/core';
import { FormBuilder,Validators, ReactiveFormsModule, FormGroup, FormControl} from '@angular/forms';
import { Exercise } from '../../../exercises/models/exercise.model';
import { TRACKING_MODE_FIELDS } from '../../../exercises/models/tracking-mode';


@Component({
  imports: [ReactiveFormsModule],
  selector: 'workout-exercise-editor',
  styleUrl: './workout-exercise-editor.scss',
  templateUrl: './workout-exercise-editor.html',
})
export class WorkoutExerciseEditor implements OnInit {
  exercise = input.required<Exercise>();

  private fb = inject(FormBuilder);

  exerciseForm = this.fb.group({
    exerciseId: ['', Validators.required],
    notes: [''],
    sets: this.fb.array<FormGroup>([])
  });

  ngOnInit(): void {
    this.exerciseForm.patchValue({exerciseId: this.exercise().id})

    this.addSet();
  }

  addSet(): void {
    this.exerciseForm.controls.sets.push(this.createSetForm());
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

    return this.fb.group(controls);
  }
}
