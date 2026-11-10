export interface NavigationItem {
  path: string;
  label: string;
}

export const navigationItems: NavigationItem[] = [
  { label: 'Home', path: '' },
  { label: 'Exercises', path: 'exercises' },
  { label: 'Workouts', path: 'workouts' },
  { label: 'Profile', path: 'profile' },
];