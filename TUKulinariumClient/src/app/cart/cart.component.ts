import { Component } from '@angular/core';
import { DishCollection } from '../models/UnionTypes';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent {
  cartItems: DishCollection[] = [];
  constructor(protected cartService: CartService) {}

  ngOnInit() {
    this.cartService.cart$.subscribe((dishes) => {
      this.cartItems = dishes;
    });
  }

  getTotal() {
    return this.cartItems.reduce((total, dish) => total + dish.DishPrice, 0);
  }

  removeFromCart(dishId: number) {
    this.cartService.removeFromCart(dishId);
  }
}
