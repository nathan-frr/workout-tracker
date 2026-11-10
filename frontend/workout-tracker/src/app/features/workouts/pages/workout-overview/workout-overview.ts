import { Component, inject, OnInit } from '@angular/core';
import { WorkoutsStore } from '../../data-access/workouts.store';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'workout-overview',
  styleUrl: './workout-overview.scss',
  templateUrl: './workout-overview.html',
})
export class WorkoutOverview implements OnInit {
  workoutsStore = inject(WorkoutsStore);
  private router = inject(Router);

  readonly workouts = this.workoutsStore.workouts;
  readonly loading = this.workoutsStore.loading;
  readonly error = this.workoutsStore.error;

  ngOnInit(): void {
    this.workoutsStore.loadWorkouts();
  }

  constructor() {}

  createWorkout(): void {
    this.router.navigate(['/workouts/new']);
  }
}
