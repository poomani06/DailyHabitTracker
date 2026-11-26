import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Habit, CreateHabit, UpdateHabit } from '../models/habit';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HabitService {

  private apiUrl = `${environment.apiUrl}/habits`;

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
    return this.http.put<void>(`${this.apiUrl}/${id}`, habit);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
  completeToday(id: number): Observable<{ message: string }> {
  return this.http.post<{ message: string }>(
    `${this.apiUrl}/${id}/complete`,
    {}
  );
}

undoToday(id: number): Observable<{ message: string }> {
  return this.http.delete<{ message: string }>(
    `${this.apiUrl}/${id}/complete`
  );
}
}