export class Dish {
  DishId: number;
  DishName: string;
  DishPrice: number;

  constructor(id: number, name: string, price: number) {
    this.DishId = id;
    this.DishName = name;
    this.DishPrice = price;
  }
}
