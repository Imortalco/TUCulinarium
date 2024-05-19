export class Dish {
  DishId: number;
  DishName: string;
  DishPrice: number;
  DishIngredients?: string[];

  constructor(id: number, name: string, price: number, ingredients: string[]) {
    this.DishId = id;
    this.DishName = name;
    this.DishPrice = price;
    this.DishIngredients = ingredients;
  }
}
