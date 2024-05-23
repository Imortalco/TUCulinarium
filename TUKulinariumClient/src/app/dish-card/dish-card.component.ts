import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Dish } from '../models/Dish';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-dish-card',
  templateUrl: './dish-card.component.html',
  styleUrls: ['./dish-card.component.css'],
})
export class DishCardComponent {
  @Input() dish: Dish;
  @Input() category: string;

  constructor(protected cartService: CartService) {}
  addToCart(dish: Dish): void {
    if (dish) {
      this.cartService.addToCart(dish, 1);
    }
  }
}
