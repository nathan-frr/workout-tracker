import { Component, inject, OnInit } from '@angular/core';
import { WorkoutCreate } from '../workout-create/workout-create';
import { WorkoutsStore } from '../../data-access/workouts.store';

@Component({
  imports: [WorkoutCreate],
  selector: 'workout-overview',
  styleUrl: './workout-overview.scss',
  templateUrl: './workout-overview.html',
})
export class WorkoutOverview implements OnInit {
  workoutsStore = inject(WorkoutsStore);

  readonly workouts = this.workoutsStore.workouts;
  readonly loading = this.workoutsStore.loading;
  readonly error = this.workoutsStore.error;

  ngOnInit(): void {
    this.workoutsStore.loadWorkouts();
  }

  constructor() {}
}
