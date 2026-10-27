import { Component } from '@angular/core';
import { ExerciseListComponent } from '../exercises/pages/exercise-list/exercise-list';

@Component({
  selector: 'app-home-screen',
  templateUrl: './home-screen.html',
  styleUrls: ['./home-screen.scss'],
  imports: [ExerciseListComponent],
})
export class HomeScreen {}