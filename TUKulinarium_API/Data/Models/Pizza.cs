using TUKulinarium_API.Helpers.BaseClasses;
using TUKulinarium_API.Helpers.Enums;

namespace TUKulinarium_API.Data.Models
{
    public class Pizza : Dish
    {
        public string Ingredients {get; set;}
        public Sauces PizzaSauce {get; set;}
        public DoughTypes PizzaDough {get; set;}
        public PizzaSizes PizzaSize {get; set;}
    }
}