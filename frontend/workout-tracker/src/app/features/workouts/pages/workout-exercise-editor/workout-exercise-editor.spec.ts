import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WorkoutExerciseEditor } from './workout-exercise-editor';

describe('WorkoutExerciseEditor', () => {
  let component: WorkoutExerciseEditor;
  let fixture: ComponentFixture<WorkoutExerciseEditor>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkoutExerciseEditor],
    }).compileComponents();

    fixture = TestBed.createComponent(WorkoutExerciseEditor);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
