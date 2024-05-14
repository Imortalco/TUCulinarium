using Microsoft.AspNetCore.Identity;
using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserProfile> GetUserProfileAsync(string username);
        public Task<UserProfile> UpdateUserProfileAsync(UserProfile userProfile);
        public Task<IdentityResult> ChangePasswordAsync(string username, string oldPassword, string newPassword);
    }
}