using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TUKulinarium_API.Data.Models;
using TUKulinarium_API.Data.Repositories;
using TUKulinarium_API.Interfaces;

namespace TUKulinarium_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfileAsync(string username)
        {
            var result = await _userRepository.GetUserProfileAsync(username);
            if (result == null)
            {
                _logger.LogError("There was an error getting the user ");
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateUserProfileAsync(UserProfile userProfile)
        {
            var result = await _userRepository.UpdateUserProfileAsync(userProfile);
            if (result == null)
            {
                _logger.LogError("There was an error updating the user ");
                return BadRequest();
            }
            return Ok(result);
        }
    }

}