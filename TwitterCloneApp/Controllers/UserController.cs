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
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto addUserDto)
        {
            await _service.AddUserAsync(addUserDto);
            return Ok();
        }

		[HttpPost("[action]")]
		public async Task<IActionResult> FindUserByNameAsync(UserNameDto userNameDto)
		{
			await _service.FindUserByNameAsync(userNameDto);
			return Ok();
		}

		[HttpPut("[action]")]
		public async Task<IActionResult> UpdateUserAsync(string userName, UpdateUserDto updateUserDto)
		{
            await _service.UpdateUserAsync(userName,updateUserDto);
			return Ok(updateUserDto);
		}

		
		


	}
}
