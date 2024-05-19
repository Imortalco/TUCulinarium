import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Dish } from '../models/Dish';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DishService {
  private apiUrl: string = 'https://localhost:8000/api';

  constructor(private http: HttpClient) {}

  getDishesByCategory(category: string): Observable<Dish[]> {
    const dishesUrl = `${this.apiUrl}/dishes/${category}`;
    return this.http.get<Dish[]>(dishesUrl);
  }
}
