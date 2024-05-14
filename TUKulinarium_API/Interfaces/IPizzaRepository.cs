using TUKulinarium_API.Data.Models;
using TUKulinarium_API.Helpers.Enums;

namespace TUKulinarium_API.Interfaces
{
    public interface IPizzaRepository
    {
        Task<Pizza> GetPizzaByIdAsync(int pizzaId);
        Task<IEnumerable<Pizza>> GetPizzas();
        Task<PizzaSizes> ChoosePizzaSize();
        Task<Sauces> ChoosePizzaSauce();
        Task<DoughTypes> ChoosePizzaDough();
    }
}