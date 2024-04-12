using Microsoft.AspNetCore.Identity;
using TUKulinarium_API.Data.DTOs;
using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender<User> _emailSender;
        private readonly DataContext _context;
        private readonly ILogger<AuthRepository> _logger;

        public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO)
        {
            if(registerDTO == null)
            {
                _logger.LogError("User is invalid");
                return IdentityResult.Failed(new IdentityError { Description = "Registration failed due to invalid data" });
            }
            try
            {
                var userToCreate = new User
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,
                };

                // Create the userToCreate using UserManager
                var result = await _userManager.CreateAsync(userToCreate, registerDTO.Password);

                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByEmailAsync(userToCreate.Email);

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(createdUser);
                    string baseUrl = _configuration["ApiUrl"];
                    string tokenUrl = $"{baseUrl}/auth/confirm-email?token={token}";

                    await _emailSender.SendConfirmationLinkAsync(createdUser, createdUser.Email, tokenUrl);

                    var userProfileData = new UserProfile
                    {
                        FirstName = registerDTO.FirstName,
                        LastName = registerDTO.LastName,
                        Email = registerDTO.Email,
                        PhoneNumber = registerDTO.PhoneNumber,
                        UserId = createdUser!.Id,
                    };

                    _context.UserProfiles.Add(userProfileData);

                    await _context.SaveChangesAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user registration.");

                return IdentityResult.Failed(new IdentityError { Description = "An error occurred during user registration." });
            }



        }

        public async Task<SignInResult> SignInAsync(string Email, string Password, bool rememberMe)
        {
            if (Email == null || Password == null)
            {
                _logger.LogError("Email or password is missing");
                return SignInResult.Failed;
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(Email, Password, rememberMe, lockoutOnFailure: false);
                if (result.Succeeded) return result;
                else return SignInResult.Failed;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user sign in.");
                return SignInResult.Failed;
            }
        }
    }
}