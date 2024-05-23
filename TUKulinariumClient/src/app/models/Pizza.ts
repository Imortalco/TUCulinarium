import { DoughType } from '../enums/DoughTypes';
import { Sauces } from '../enums/Sauces';
import { PizzaSizes } from '../enums/Sizes';
import { Dish } from './Dish';

export class Pizza extends Dish {
  pizzaSauce: Sauces;
  pizzaDough: DoughType;
  pizzaSize: PizzaSizes;

  
}
