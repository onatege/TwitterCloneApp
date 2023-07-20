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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var usernameDto = new UsernameDto { UserName = username };
            var user = await _service.GetUserByUsernameAsync(usernameDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto addUserDto)
        {
            var user = await _service.AddUserAsync(addUserDto);
            return CreatedAtAction(nameof(GetUserByUsername), new { username = user.UserName }, user);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(string username, UpdateUserDto updateUserDto)
        {
            var usernameDto = new UsernameDto { UserName = username };
            var existingUser = await _service.GetUserByUsernameAsync(usernameDto);

            if (existingUser == null)
            {
                return NotFound();
            }

            await _service.UpdateUserAsync(updateUserDto);
            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SoftDeleteUser(string username)
        {
            var deleteUserDto = new DeleteDto { UserName = username, IsDeleted = true, DeletedAt = DateTime.UtcNow };
            await _service.SoftDeleteUserAsync(deleteUserDto);

            return NoContent();
        }


    }
}
