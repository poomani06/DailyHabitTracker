
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  Habit,
  CreateHabit
} from '../../models/habit';

import { HabitService } from '../../services/habit.service';

@Component({
  selector: 'app-habit-page',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './habit-page.html',
  styleUrl: './habit-page.css'
})
export class HabitPage implements OnInit {

  habits: Habit[] = [];

  habitName = '';
  habitDescription = '';

  editingId: number | null = null;

  loading = false;
  errorMessage = '';
  successMessage = '';

  constructor(private habitService: HabitService) {}

  ngOnInit(): void {
    this.loadHabits();
  }

  loadHabits(): void {
    this.loading = true;

    this.habitService.getAll().subscribe({
      next: (data) => {
        this.habits = data;
        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'Unable to load habits.';
        this.loading = false;
      }
    });
  }

  saveHabit(): void {

    if (!this.habitName.trim()) {
      this.errorMessage = 'Please enter a habit name.';
      return;
    }

    const habit: CreateHabit = {
      name: this.habitName.trim(),
      description: this.habitDescription.trim() || null
    };

    this.loading = true;
    this.errorMessage = '';

    if (this.editingId !== null) {

      this.habitService.update(this.editingId, habit).subscribe({
        next: () => {
          this.successMessage = 'Habit updated successfully.';
          this.resetForm();
          this.loadHabits();
        },
        error: () => {
          this.errorMessage = 'Unable to update habit.';
          this.loading = false;
        }
      });

    } else {

      this.habitService.create(habit).subscribe({
        next: () => {
          this.successMessage = 'Habit added successfully.';
          this.resetForm();
          this.loadHabits();
        },
        error: () => {
          this.errorMessage = 'Unable to add habit.';
          this.loading = false;
        }
      });

    }
  }

  editHabit(habit: Habit): void {
    this.editingId = habit.id;
    this.habitName = habit.name;
    this.habitDescription = habit.description ?? '';
    this.errorMessage = '';
    this.successMessage = '';
  }

  deleteHabit(id: number): void {

    if (!confirm('Are you sure you want to delete this habit?')) {
      return;
    }

    this.loading = true;

    this.habitService.delete(id).subscribe({
      next: () => {
        this.successMessage = 'Habit deleted successfully.';
        this.loadHabits();
      },
      error: () => {
        this.errorMessage = 'Unable to delete habit.';
        this.loading = false;
      }
    });
  }

  resetForm(): void {
    this.habitName = '';
    this.habitDescription = '';
    this.editingId = null;
  }
  completeHabit(id: number): void {
  this.loading = true;
  this.errorMessage = '';

  this.habitService.completeToday(id).subscribe({
    next: () => {
      this.successMessage = 'Habit completed successfully.';
      this.loadHabits();
    },
    error: () => {
      this.errorMessage = 'Unable to complete habit.';
      this.loading = false;
    }
  });
}

undoHabit(id: number): void {
  this.loading = true;
  this.errorMessage = '';

  this.habitService.undoToday(id).subscribe({
    next: () => {
      this.successMessage = 'Habit completion undone.';
      this.loadHabits();
    },
    error: () => {
      this.errorMessage = 'Unable to undo habit completion.';
      this.loading = false;
    }
  });
}
}
