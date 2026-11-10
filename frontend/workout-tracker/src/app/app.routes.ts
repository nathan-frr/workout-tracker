import { Routes } from '@angular/router';
import { ExerciseListComponent } from './features/exercises/pages/exercise-list/exercise-list';
import { HomeScreen } from './features/home/home-screen';
import { ProfileScreen } from './features/profile/profile-screen';
import { WorkoutCreate } from './features/workouts/pages/workout-create/workout-create';

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
		component: WorkoutCreate,
	},
	{
		path: 'profile',
		component: ProfileScreen,
	},
];
