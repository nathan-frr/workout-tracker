import { Routes } from '@angular/router';
import { ExerciseListComponent } from './features/exercises/pages/exercise-list/exercise-list';
import { HomeScreen } from './features/home/home-screen';
import { ProfileScreen } from './features/profile/profile-screen';
import { WorkoutOverview } from './features/workouts/pages/workout-overview/workout-overview';
import { WorkoutCreate } from './features/workouts/pages/workout-create/workout-create';
import { authGuard } from './shared/auth/auth.guard';
import { LoginScreen } from './features/login/login-screen';
import { RegisterScreen } from './features/register/register-screen';

export const routes: Routes = [
	{
		path: 'login',
		component: LoginScreen,
	},
	{
		path: 'register',
		component: RegisterScreen,
	},
	{
		path: '',
		component: HomeScreen,
    	canActivate: [authGuard]
	},
	{
		path: 'exercises',
		component: ExerciseListComponent,
    	canActivate: [authGuard]
	},
	{
		path: 'workouts',
		component: WorkoutOverview,
    	canActivate: [authGuard]
	},
	{
		path: 'workouts/new',
		component: WorkoutCreate,
    	canActivate: [authGuard]
	},
	{
		path: 'profile',
		component: ProfileScreen,
    	canActivate: [authGuard]
	},
];
