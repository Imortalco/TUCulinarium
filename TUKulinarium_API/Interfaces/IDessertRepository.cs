using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Interfaces
{
    public interface IDessertRepository
    {
        public Task<List<Dessert>> GetAllDesserts();
        public Task<Dessert> GetDessertByIdAsync(int dessertId);
    }
}