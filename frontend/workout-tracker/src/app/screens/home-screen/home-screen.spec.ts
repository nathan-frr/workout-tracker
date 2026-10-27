import { TestBed } from '@angular/core/testing';
import { HomeScreen } from './home-screen';

describe('HomeScreen', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeScreen],
    }).compileComponents();
  });

  it('should render the welcome message', () => {
    const fixture = TestBed.createComponent(HomeScreen);
    const compiled = fixture.nativeElement as HTMLElement;

    expect(compiled.textContent).toContain('WorkoutTracker');
    expect(compiled.textContent).toContain('Welcome to the workout tracker');
  });
});