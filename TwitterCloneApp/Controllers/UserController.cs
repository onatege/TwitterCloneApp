using Microsoft.AspNetCore.Mvc;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.DTO.User;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Response;
using System.Net;

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

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetUserProfile(string username)
        //{
        //    var userProf = await _service.GetUserProfileAsync(username);
        //}

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

		//[HttpPut("[action]")]
		//public async Task<IActionResult> UpdateUser(string username, UpdateUserDto updateUserDto)
		//{
		//    

		//    await _service.UpdateUserAsync(updateUserDto);
		//    return NoContent();
		//}

		//[HttpPut("[action]")]
		//public async Task<IActionResult> SoftDeleteUser(string username)
		//{
		//    await _service.SoftDeleteUserAsync(deleteUserDto);

		//    return NoContent();
		//}


	}
}
