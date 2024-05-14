using TUKulinarium_API.Data.Models;
using TUKulinarium_API.Helpers.Enums;

namespace TUKulinarium_API.Interfaces
{
    public interface IDrinkRepository
    {
        public Task<IEnumerable<Drink>> GetAllDrinks();
        public Task<Drink> GetDrinkByIdAsync(int id);
        public Task<DrinkSizes> ChooseDrink();
    }
}