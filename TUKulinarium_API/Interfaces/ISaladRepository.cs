using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Interfaces
{
    public interface ISaladRepository
    {
        public Task<IEnumerable<Salad>> GetAllSalads();
        public Task<Salad> GetSaladByIdAsync(int saladId);
    }
}