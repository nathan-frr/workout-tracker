import { ComponentFixture, TestBed } from '@angular/core/testing';
import { WorkoutOverview } from './workout-overview';

describe('WorkoutOverview', () => {
  let component: WorkoutOverview;
  let fixture: ComponentFixture<WorkoutOverview>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WorkoutOverview],
    }).compileComponents();

    fixture = TestBed.createComponent(WorkoutOverview);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
