using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository;

namespace TwitterCloneApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagController : ControllerBase
	{
		private readonly AppDbContext _dbContext;
		public TagController(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTags()
		{
			var tweets = await _dbContext.Tags.ToListAsync();
			return Ok(tweets);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTagsById(int id)
		{
			var tag = await _dbContext.Tags.FindAsync(id);
			return Ok(tag);
		}

		[HttpPost]
		public async Task<IActionResult> NewTag()
		{
			var tag = new Tag
			{
				Name = "#testing",
				isTrending = true,
			};
	
			await _dbContext.Tags.AddAsync(tag);
			await _dbContext.SaveChangesAsync();
			return Ok(tag);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveTag(int id)
		{
			var tag = _dbContext.Tags.Find(id);

			if(tag is null) { return NotFound(); };

			_dbContext.Tags.Remove(tag);
			await _dbContext.SaveChangesAsync();
			return Ok(tag);
		}
	}
}
