import { Component, Output } from '@angular/core';
import { Dish } from '../models/Dish';
import { DishService } from '../services/dish.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
})
export class MenuComponent {
  currentCategory: string = 'Burgers';
  categories: string[] = [
    'Burgers',
    'Pizzas',
    'Salads',
    'Drinks',
    'Desserts',
    'Sides',
  ];
  //Test data
  dishes$: Dish[] = [
    {
      DishId: 1,
      DishName: 'Monster Burger',
      DishIngredients: [
        'Onions',
        'Monster Sauce',
        'Pulled Pork',
        'Pickles',
        'Melted Cheddar',
      ],
      DishPrice: 10,
    },
    {
      DishId: 2,
      DishName: 'Monster Burger',
      DishIngredients: [
        'Onions',
        'Monster Sauce',
        'Pulled Pork',
        'Pickles',
        'Melted Cheddar',
      ],
      DishPrice: 10,
    },
    {
      DishId: 2,
      DishName: 'Monster Burger',
      DishIngredients: [
        'Onions',
        'Monster Sauce',
        'Pulled Pork',
        'Pickles',
        'Melted Cheddar',
      ],
      DishPrice: 10,
    },
  ];
  constructor(private dishService: DishService) {}

  ngOnInit(): void {
    this.getDishesByCategory(this.currentCategory);
  }

  getDishesByCategory(category: string): void {
    this.dishService
      .getDishesByCategory(category)
      .subscribe((ds: Dish[]) => (this.dishes$ = ds));
  }

  switchCategory(category: string): void {
    this.currentCategory = category;
    this.getDishesByCategory(category);
  }
}
