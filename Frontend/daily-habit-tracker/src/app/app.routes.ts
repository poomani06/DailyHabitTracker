
import { Routes } from '@angular/router';
import { HabitPage } from './features/habits/habit-page';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'habits',
    pathMatch: 'full'
  },
  {
    path: 'habits',
    component: HabitPage
  },
  {
    path: '**',
    redirectTo: 'habits'
  }
];
