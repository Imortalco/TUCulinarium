using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TUKulinarium_API.Data.DTOs;
using TUKulinarium_API.Data.Models;

namespace TUKulinarium_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository, ILogger<AuthController> logger)
        {
            _authRepository = authRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var result = await _authRepository.RegisterAsync(registerDTO);
            if (result.Succeeded)
            {

                return Ok("Registration successful");
            }
            else
            {
                _logger.LogWarning("Registration failed: {Errors}", string.Join(",", result.Errors));
                return BadRequest("There was an error while signing up");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string username, string password, bool rememberMe)
        {
            var result = await _authRepository.LoginAsync(username, password, rememberMe);
            if (result.Succeeded)
            {
                return Ok("Signed in successfully");
            }
            else
            {
                _logger.LogWarning("Login failed: {Errors}", string.Join(",", result.ToString()));
                return BadRequest("There was an error while signing in");
            }
        }
    }
}