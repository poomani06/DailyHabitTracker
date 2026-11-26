
export interface Habit {
  id: number;
  name: string;
  description: string | null;
  createdAt: string;
  isCompletedToday: boolean;
}

export interface CreateHabit {
  name: string;
  description: string | null;
}

export interface UpdateHabit {
  name: string;
  description: string | null;
}
export interface HabitHistory {
  id: number;
  habitId: number;
  habitName: string;
  completedDate: string;
}