using TUKulinarium_API.Helpers.BaseClasses;
using TUKulinarium_API.Helpers.Enums;

namespace TUKulinarium_API.Data.Models
{
    public class Burger : Dish
    {
        public string Ingredients { get; set; }
        public Sides BurgerSide { get; set; }
        public Beverages BurgerBeverage { get; set; }
    }
}