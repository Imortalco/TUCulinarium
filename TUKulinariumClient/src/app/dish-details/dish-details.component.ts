import { Component } from '@angular/core';
import { DishService } from '../services/dish.service';
import { ActivatedRoute } from '@angular/router';
import { DishCollection } from '../models/UnionTypes';
import { Pizza } from '../models/Pizza';
import { Burger } from '../models/Burger';
import { Drink } from '../models/Drink';
import { Dish } from '../models/Dish';
import { CartService } from '../services/cart.service';
import { PizzaSizes } from '../enums/Sizes';

type PizzaSizeType = keyof typeof PizzaSizes;
@Component({
  selector: 'app-dish-details',
  templateUrl: './dish-details.component.html',
  styleUrls: ['./dish-details.component.css'],
})
export class DishDetailsComponent {
  category: string;
  dishId: number;
  dish: DishCollection;
  quantity: number = 1;
  key:PizzaSizeType;
  selectedSize: PizzaSizes = PizzaSizes.Small;
  pizzaSizes: string[]= [
    PizzaSizes[PizzaSizes.Small],
    PizzaSizes[PizzaSizes.Medium],
    PizzaSizes[PizzaSizes.Large],
    PizzaSizes[PizzaSizes.Family],
  ]

  constructor(
    private dishService: DishService,
    private route: ActivatedRoute,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((param) => {
      this.category = param['category'];
      this.dishId = param['dishId'];
      this.dish = {
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
      };
      // this.dishService.getDishById(this.dishId, this.category).subscribe(ds=>{
      //   this.dish = ds;
      // });
      console.log(this.category);
    });
  }

  addToCart(dish: Dish, quantity: number): void {
    if (dish && quantity > 0) {
      this.cartService.addToCart(dish, quantity);
    }
  }

  isPizza(dish: DishCollection): dish is Pizza {
    return dish.hasOwnProperty('pizzaDough');
  }

  isBurger(dish: DishCollection): dish is Burger {
    return dish.hasOwnProperty('burgerSide');
  }

  isDrink(dish: DishCollection): dish is Drink {
    return dish.hasOwnProperty('drinkSize');
  }

  calculatePrice(): number {
    const sizePriceIncrease = this.selectedSize;
    console.log(sizePriceIncrease);
    return this.dish.DishPrice + sizePriceIncrease;
  }
}
