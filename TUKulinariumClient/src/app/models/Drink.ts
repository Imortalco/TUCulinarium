import { DrinkSizes } from '../enums/Sizes';
import { Dish } from './Dish';

export class Drink extends Dish {
  drinkSize: DrinkSizes;
}
