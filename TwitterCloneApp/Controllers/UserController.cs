using Microsoft.AspNetCore.Mvc;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.DTO.User;
using TwitterCloneApp.DTO;

namespace TwitterCloneApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var usernameDto = new UsernameDto { UserName = username };
            var user = await _userService.GetUserByUsernameAsync(usernameDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto addUserDto)
        {
            var user = await _userService.AddUserAsync(addUserDto);
            return CreatedAtAction(nameof(GetUserByUsername), new { username = user.UserName }, user);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUser(string username, UpdateUserDto updateUserDto)
        {
            var usernameDto = new UsernameDto { UserName = username };
            var existingUser = await _userService.GetUserByUsernameAsync(usernameDto);

            if (existingUser == null)
            {
                return NotFound();
            }

            await _userService.UpdateUserAsync(updateUserDto);
            return NoContent();
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> SoftDeleteUser(string username)
        {
            var deleteUserDto = new UsernameDto { UserName = username };
            var user = await _userService.GetUserByUsernameAsync(deleteUserDto);

            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            await _userService.UpdateUserAsync(user);

            return NoContent();
        }

    }
}
