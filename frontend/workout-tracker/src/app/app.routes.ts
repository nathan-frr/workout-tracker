import { Routes } from '@angular/router';
import { ExerciseListComponent } from './features/exercises/pages/exercise-list/exercise-list';
import { HomeScreen } from './features/home/home-screen';
import { ProfileScreen } from './features/profile/profile-screen';
import { WorkoutOverview } from './features/workouts/pages/workout-overview/workout-overview';

export const routes: Routes = [
	{
		path: '',
		component: HomeScreen,
	},
	{
		path: 'exercises',
		component: ExerciseListComponent,
	},
	{
		path: 'workouts',
		component: WorkoutOverview,
	},
	{
		path: 'profile',
		component: ProfileScreen,
	},
];
