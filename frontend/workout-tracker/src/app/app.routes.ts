import { Routes } from '@angular/router';

export const routes: Routes = [
	{
		path: '',
		loadComponent: () =>
			import('./features/home/home-screen').then(
				({ HomeScreen }) => HomeScreen,
			),
	},
];
