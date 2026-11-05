import { Component } from '@angular/core';
import { ExerciseListComponent } from '../exercises/pages/exercise-list/exercise-list';
import { WorkoutCreate } from '../workouts/pages/workout-create/workout-create';

@Component({
  selector: 'app-home-screen',
  templateUrl: './home-screen.html',
  styleUrls: ['./home-screen.scss'],
  imports: [ExerciseListComponent, WorkoutCreate],
})
export class HomeScreen {}