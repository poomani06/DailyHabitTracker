
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import {
  Habit,
  CreateHabit,
  UpdateHabit
} from '../models/habit';

@Injectable({
  providedIn: 'root'
})
export class HabitService {

  private apiUrl = 'https://localhost:7001/api/habits';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Habit[]> {
    return this.http.get<Habit[]>(this.apiUrl);
  }

  getById(id: number): Observable<Habit> {
    return this.http.get<Habit>(`${this.apiUrl}/${id}`);
  }

  create(habit: CreateHabit): Observable<Habit> {
    return this.http.post<Habit>(this.apiUrl, habit);
  }

  update(id: number, habit: UpdateHabit): Observable<void> {
    return this.http.put<void>(
      `${this.apiUrl}/${id}`,
      habit
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(
      `${this.apiUrl}/${id}`
    );
  }
}
