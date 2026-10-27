import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MockExercisesApiService } from '../../data-access/exercises-api.service.mock';
import { ExerciseService } from '../../data-access/exercises-api.service';
import { ExerciseListComponent } from './exercise-list';

describe('ExerciseListComponent', () => {
  let component: ExerciseListComponent;
  let fixture: ComponentFixture<ExerciseListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExerciseListComponent],
      providers: [
        { provide: ExerciseService, useClass: MockExercisesApiService },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(ExerciseListComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
