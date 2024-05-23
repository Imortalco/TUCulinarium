import { Injectable } from '@angular/core';
import { Dish } from '../models/Dish';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cart = new BehaviorSubject<Dish[]>([]);
  cart$ = this.cart.asObservable();

  addToCart(Dish: Dish, initialQuantity: number) {
    const currentCart = this.cart.value;

    const existingItem = currentCart.find(
      (item) => item.DishId === Dish.DishId
    );

    if (existingItem) {
      this.cart.next(
        currentCart.map((item) =>
          item.DishId === Dish.DishId
            ? { ...item, quantity: item.DishQuantity + 1 }
            : item
        )
      );
    } else {
      this.cart.next([
        ...currentCart,
        { ...Dish, DishQuantity: initialQuantity },
      ]);
    }
  }

  removeFromCart(dishId: number) {
    const currentCart = this.cart.value;
    this.cart.next(currentCart.filter((item) => item.DishId !== dishId));
  }
}
