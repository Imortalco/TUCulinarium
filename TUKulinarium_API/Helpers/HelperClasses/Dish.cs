using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TUKulinarium_API.Helpers.BaseClasses
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
    }
}