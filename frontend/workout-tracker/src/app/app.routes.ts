import { Routes } from '@angular/router';

export const routes: Routes = [
	{
		path: '',
		loadComponent: () =>
			import('./screens/home-screen/home-screen').then(
				({ HomeScreen }) => HomeScreen,
			),
	},
];
