using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Interfaces
{
    public interface IUserProfileRepository
    {
        public Task<UserProfile> GetUserProfileById(int ProfileId);
        public Task<UserProfile> UpdateUserProfile(UserProfile userProfile);
        public Task<bool> ChangePassword(int ProfileId, string oldPassword, string newPassword);
    }
}