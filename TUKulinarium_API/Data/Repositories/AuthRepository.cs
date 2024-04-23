using System.Text;
using System.Web;
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

        public AuthRepository(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, IEmailSender<User> emailSender, DataContext context, ILogger<AuthRepository> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _context = context;
            _logger = logger;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO == null)
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
                    UserProfile = new UserProfile
                    {
                        UserName = registerDTO.UserName,
                        FirstName = registerDTO.FirstName,
                        LastName = registerDTO.LastName,
                        Email = registerDTO.Email,
                        PhoneNumber = registerDTO.PhoneNumber,
                        Address = registerDTO.Address,
                    }
                };

                // Create the userToCreate using UserManager
                var result = await _userManager.CreateAsync(userToCreate, registerDTO.Password);

                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByEmailAsync(userToCreate.Email);

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(createdUser);
                    string encodedToken = HttpUtility.UrlEncode(token);
                    string baseUrl = _configuration["ApiUrl"];
                    string tokenUrl = $"<p><a href=\"{baseUrl}/auth/confirmEmail?userId={createdUser.Id}&code={encodedToken}\">Here</a></p>";

                    await _emailSender.SendConfirmationLinkAsync(createdUser, createdUser.Email, tokenUrl);

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
        private async Task<User> GetUserByUsernameOrEmailAsync(string username)
        {
            if (username.Contains('@'))
            {
                return await _userManager.FindByEmailAsync(username);
            }
            else
            {
                return await _userManager.FindByNameAsync(username);
            }
        }

        public async Task<SignInResult> LoginAsync(string Username, string Password, bool rememberMe)
        {

            User user = await GetUserByUsernameOrEmailAsync(Username);
            try
            {
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, Password, rememberMe, lockoutOnFailure: false);
                    return result.Succeeded ? result : SignInResult.Failed;
                }
                else
                {
                    return SignInResult.Failed;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during user sign in.");
                return SignInResult.Failed;
            }

        }
    }
}