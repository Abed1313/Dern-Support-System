using Dern_Support_System.Models.DTO;
using Dern_Support_System.Models.DTO.Response;
using Dern_Support_System.Repository.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dern_Support_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUser _userManager;

        public AccountController(IUser userManager)
        {
            _userManager = userManager;
        }

        // POST: api/Account/Register
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerEmployeeDTO)
        {
            var response = await _userManager.Register(registerEmployeeDTO);

            if (response.Success)
            {
                return Ok(response.User);
            }
            return BadRequest(response.Message);
        }


        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<ActionResult<LogDTo>> Login(LoginDto loginDto)
        {
            var user = await _userManager.LoginUser(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid credentials" });
            }

            return Ok(user);
        }

        // POST: api/Account/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            var username = User.Identity?.Name;
            if (username == null)
            {
                return Unauthorized(new { Message = "No user logged in" });
            }

            await _userManager.LogoutUser(username);
            return Ok(new { Message = "User logged out successfully" });
        }

        // GET: api/Account/Profile
        [Authorize(Roles = "Admin")]
        [HttpGet("Profile")]
        public async Task<ActionResult<LogDTo>> Profile()
        {
            var profile = await _userManager.userProfile(User);
            if (profile == null)
            {
                return Unauthorized(new { Message = "Profile not found" });
            }

            return Ok(profile);
        }

        [HttpDelete("DeleteAccount")]
        public async Task DeleteAccount(string username)
        {
            var user = await _userManager.DeleteAccount(username);
        }
    }
}
