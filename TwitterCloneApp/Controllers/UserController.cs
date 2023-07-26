using Microsoft.AspNetCore.Mvc;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.API.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync(AddUserDto addUserDto)
        {
            await _userService.AddUserAsync(addUserDto);
            return Ok();
        }

		[HttpPost("[action]")]
		public async Task<IActionResult> FindUserByIdAsync(int id)
		{
			var user = await _userService.FindUserByIdAsync(id);
			return Ok(user);
		}

		[HttpPut("[action]")]
		public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
		{
            await _userService.UpdateUserAsync(id,updateUserDto);
			return Ok(updateUserDto);
		}
	}
}
