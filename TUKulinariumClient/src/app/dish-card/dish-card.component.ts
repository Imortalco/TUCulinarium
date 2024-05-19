import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Dish } from '../models/Dish';

@Component({
  selector: 'app-dish-card',
  templateUrl: './dish-card.component.html',
  styleUrls: ['./dish-card.component.css'],
})
export class DishCardComponent {
  @Input() dish: Dish;
  @Output() onAddToCart: EventEmitter<any> = new EventEmitter();

  constructor() {
    
  }
  addToCart():void{
    console.log('Dish added to cart');
  }

  navToCustomization():void{
    console.log('navToCustomization');
  }
}
