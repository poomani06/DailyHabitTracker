import { Routes } from '@angular/router';
import { HabitPage } from './features/habits/habit-page';
import { HistoryPage } from './features/history/history-page/history-page';

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
    path: 'history',
    component: HistoryPage
  },
  {
    path: '**',
    redirectTo: 'habits'
  }
];