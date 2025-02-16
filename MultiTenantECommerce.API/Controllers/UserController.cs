using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces.Services;

namespace MultiTenantECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromQuery] Guid tenantId, [FromBody] UserDto userDto)
        {
            var user = await _userService.CreateUserAsync(tenantId, userDto);
            return CreatedAtAction(nameof(GetUserById), new {userId = user.Id}, user);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserByIdASync(userId);
            if(user == null) return NotFound();
             return Ok(user);
        }


        [HttpGet]
        public async Task<IActionResult> GetUserByEmail(string email, string password)
        {
            var user = await _userService.GetUserByEmailAsync(email, password);

            if (user == null)
                return Unauthorized(new { success = false, message = "E-posta veya şifre hatalı!" });

            return Ok(new { success = true, message = "Giriş başarılı!", user });
        }


    }
}
