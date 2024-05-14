using TUKulinarium_API.Helpers.BaseClasses;
using TUKulinarium_API.Helpers.Enums;

namespace TUKulinarium_API.Data.Models
{
    public class Drink : Dish
    {
        public DrinkType drinkType { get; set; }
        public DrinkSizes DrinkSize { get; set; }
    }
}