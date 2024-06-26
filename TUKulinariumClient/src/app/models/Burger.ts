import { Beverages } from '../enums/Beverages';
import { Sides } from '../enums/Sides';
import { Dish } from './Dish';

export class Burger extends Dish {
  burgerSide: Sides;
  burgerBeverage: Beverages;
}
