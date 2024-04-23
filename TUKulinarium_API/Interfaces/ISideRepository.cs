using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Interfaces
{
    public interface ISideRepository
    {
        public Task<IEnumerable<Side>> GetAllSides();
        public Task<Side> GetSideByIdAsync(int sideId);
    }
}