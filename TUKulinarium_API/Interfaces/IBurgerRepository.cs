using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Interfaces
{
    public interface IBurgerRepository
    {
        public Task<Burger> GetBurgerByIdAsync(int burgerId);
        public Task<IEnumerable<Burger>> GetBurgerListAsync();
    }
}