using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Interfaces;
namespace ESAN.Shopping.API.Controllers
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
        public async Task<IActionResult> Signup([FromBody] UserCreateDTO user)
        {
            var id = await _userService.Signup(user);
            return Ok(new { Id = id });
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO login)
        {
            var user = await _userService.SignIn(login.Email, login.Password);
            if (user == null)
                return Unauthorized();
            return Ok(user);
        }
    }
}
