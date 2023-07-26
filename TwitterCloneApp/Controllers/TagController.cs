using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository;
using TwitterCloneApp.Core.Abstracts;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Tag;

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
        [HttpGet("[action]")]
		public async Task<IActionResult> GetTagByIdAsync(int id)
		{
			var tag = await _tagService.GetTagByIdAsync(id);
			return Ok(tag);
		}

		[HttpPost]
		public async Task<IActionResult> AddTagAsync(AddTagDto addTagDto)
		{
            await _tagService.AddTagAsync(addTagDto);
            return Ok();
        }
		
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveTagAsync(int id)
		{
			await _tagService.RemoveTagAsync(id);
			return Ok();
		}
		
    }
}
