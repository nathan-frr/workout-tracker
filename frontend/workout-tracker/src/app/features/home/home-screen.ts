import { Component, inject, OnInit, signal } from '@angular/core';
import { ExerciseService } from '../exercises/data-access/exercises-api.service';
import { Exercise } from '../exercises/models/exercise.model';

@Component({
  selector: 'app-home-screen',
  templateUrl: './home-screen.html',
  styleUrls: ['./home-screen.scss'],
})
export class HomeScreen implements OnInit {

  private readonly exerciseService = inject(ExerciseService);
  
  ngOnInit(): void {
      this.exerciseService.getExercises().subscribe((fetchedExercises) => console.log(fetchedExercises));
  }

}