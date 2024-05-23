import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Dish } from '../models/Dish';
import { Observable, map } from 'rxjs';
import { Burger } from '../models/Burger';
import { Dessert } from '../models/Dessert';
import { Drink } from '../models/Drink';
import { Pizza } from '../models/Pizza';
import { Salad } from '../models/Salad';
import { DishCollection } from '../models/UnionTypes';
import { Side } from '../models/Side';

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

  getDishById(id: number, category:string): Observable<DishCollection> {
    const dishUrl = `${this.apiUrl}/${category}/${id}`;
    return this.http.get<DishCollection>(dishUrl).pipe(
      map(data => {
        switch (category) {
          case 'Pizza':
            return data as Pizza;
          case 'Burger':
            return data as Burger;
          case 'Salad':
            return data as Salad;
          case 'Dessert':
            return data as Dessert;
          case 'Drink':
            return data as Drink;
          case 'Side':
            return data as Side;
          default:
            throw Error('There was an error getting the dish details');
        }
      })
    );;
  }
}
