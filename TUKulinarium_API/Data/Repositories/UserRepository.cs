
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using TUKulinarium_API.Data.Models;
using TUKulinarium_API.Interfaces;
using System.Security.Claims;

namespace TUKulinarium_API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserRepository> _logger;

        private readonly DataContext _context;

        public UserRepository(UserManager<User> userManager, ILogger<UserRepository> logger, DataContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }

        public async Task<UserProfile> GetUserProfileAsync(string username)
        {
            var user = _context.Set<User>().Where(u => u.UserName == username).FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentException(username + " does not exist");
            }
            return user.UserProfile;
        }
        public async Task<UserProfile> UpdateUserProfileAsync(UserProfile userProfile)
        {
            var userToUpdate = await _userManager.FindByIdAsync(userProfile.UserId);

            if (userToUpdate == null)
            {
                _logger.LogError($"User with ID {userProfile.UserId} not found for profile update");
                throw new ArgumentException("No user with this id found");
            }

            userToUpdate.UserProfile = new UserProfile
            {
                UserName = userProfile.UserName,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Email = userProfile.Email,
                Address = userProfile.Address,
            };
            // Update the user in the database
            var result = await _userManager.UpdateAsync(userToUpdate);

            if (result.Succeeded)
            {
                return userToUpdate.UserProfile;
            }
            else
            {
                _logger.LogError($"Error updating user profile: {result.Errors.FirstOrDefault().Description}");
                return null;
            }
        }
        public async Task<IdentityResult> ChangePasswordAsync(string userName, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }


    }
}