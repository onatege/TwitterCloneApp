using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository;

namespace TwitterCloneApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly AppDbContext _context;
		public UserController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _context.Users.ToListAsync();
			return Ok(users);
		}

		[HttpPost]
		public async Task<IActionResult> NewUser()
		{
			var user = new User
			{
				DisplayName = "canbo",
				UserName = "canbo1",
				Email = "canbo@gmail.com",
				Password = "123",
				IsDeleted = false,
				Biography = "mobven",
			};

			await _context.AddAsync(user);
			await _context.SaveChangesAsync();
			return Ok(user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, User updatedUser)
		{
			var user = await _context.Users.FindAsync(id);

			if(user == null)
			{
				return NotFound();
			}
			user.DisplayName = updatedUser.DisplayName;
			user.UserName = updatedUser.UserName;
			user.Email = updatedUser.Email;
			user.Password = updatedUser.Password;
			user.Biography = updatedUser.Biography;

			_context.Update(user);
			await _context.SaveChangesAsync();

			return Ok(user);

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);

			if (user.IsDeleted == false)
			{
				user.IsDeleted = true;
				_context.Update(user);
				await _context.SaveChangesAsync();
			}
			else
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}

			return Ok(user);
		}
    }
}
