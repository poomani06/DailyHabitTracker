
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { finalize } from 'rxjs';

import { HabitHistory } from '../../../models/habit';
import { HabitService } from '../../../services/habit.service';

@Component({
  selector: 'app-history-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './history-page.html',
  styleUrl: './history-page.css'
})
export class HistoryPage implements OnInit {

  history: HabitHistory[] = [];
  loading = false;
  errorMessage = '';

  constructor(private habitService: HabitService) {}

  ngOnInit(): void {
    this.loadHistory();
  }

  loadHistory(): void {
    this.loading = true;
    this.errorMessage = '';

    this.habitService.getHistory()
      .pipe(
        finalize(() => {
          this.loading = false;
          console.log('Loading finished');
        })
      )
      .subscribe({
        next: (data) => {
          console.log('History API Response:', data);

          this.history = data;
          console.log('History records:', this.history.length);
        },
        error: (error) => {
          console.error('History API Error:', error);
          this.errorMessage = 'Unable to load habit history.';
        }
      });
  }
}
