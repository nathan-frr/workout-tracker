import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WorkoutExerciseEditor } from './workout-exercise-editor';
import { ReactiveFormsModule } from '@angular/forms';
import { Exercise } from '../../../exercises/models/exercise.model';
import { EquipmentType } from '../../../exercises/models/equipment-type';
import { TrackingMode } from '../../../exercises/models/tracking-mode';

describe('WorkoutExerciseEditor', () => {
  let component: WorkoutExerciseEditor;
  let fixture: ComponentFixture<WorkoutExerciseEditor>;
  const mockExercise: Exercise = {
      id: '00000000-0000-0000-0000-000000000001',
      name: 'Bench Press',
      description: 'Barbell chest press.',
      equipmentType: EquipmentType.Barbell,
      mediaUrl: null,
      trackingMode: TrackingMode.RepsAndWeight,
      isBuiltIn: true,
      muscleGroups: [
        { id: 1, name: 'Chest', role: 'Primary' },
      ],
    };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkoutExerciseEditor, ReactiveFormsModule],
    }).compileComponents();

    fixture = TestBed.createComponent(WorkoutExerciseEditor);
    component = fixture.componentInstance;
    fixture.componentRef.setInput('exercise' , mockExercise);
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
