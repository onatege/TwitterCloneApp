using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository;
using TwitterCloneApp.Core.Abstracts;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace TwitterCloneApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TagController : ControllerBase
	{
		private readonly ITagService _tagService;
		public TagController(ITagService tagService)
		{
			_tagService = tagService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTagsAsync()
		{
			var tags = await _tagService.GetAllTagsAsync();
			return Ok(tags);
		}
        [HttpPost("[action]")]
		public async Task<IActionResult> GetTagByIdAsync(int id)
		{
			var tag = await _tagService.GetTagByIdAsync(id);
			return Ok(tag);
		}
        /*
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
		*/
    }
}
