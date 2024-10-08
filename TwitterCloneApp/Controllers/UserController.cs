﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.User;
using TwitterCloneApp.DTO.Response;
using TwitterCloneApp.Service.Filters;

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
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }
        [ServiceFilter(typeof(NotFoundFilter<User>))]
		[HttpGet("[action]")]
		public async Task<IActionResult> GetUserWithFollowersAndTweetsByIdAsync(int id)
		{
			var user = await _userService.GetUserWithFollowersAndTweetsByIdAsync(id);
            return Ok(CustomResponseDto.Success(user, HttpStatusCode.OK));
        }

		[HttpPut("[action]")]
		public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
		{
            await _userService.UpdateUserAsync(id,updateUserDto);
            return Ok(CustomResponseDto.Success(updateUserDto, HttpStatusCode.OK));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> DeactivateUserAsync(int id)
        {
            await _userService.DeactivateUserAsync(id);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ActivateUserAsync(int id)
        {
            await _userService.ActivateUserAsync(id);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveUserAsync(int id)
        {
            await _userService.RemoveUserAsync(id);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }
    }
}
