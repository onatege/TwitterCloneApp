using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.Tag;
using TwitterCloneApp.DTO.Response;

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
            return Ok(CustomResponseDto.Success(tags, HttpStatusCode.OK));
        }
        [HttpGet("[action]")]
		public async Task<IActionResult> GetTagByIdAsync(int id)
		{
			var tag = await _tagService.GetTagByIdAsync(id);
            return Ok(CustomResponseDto.Success(tag, HttpStatusCode.OK));
        }

		[HttpPost]
		public async Task<IActionResult> AddTagAsync(AddTagDto addTagDto)
		{
            await _tagService.AddTagAsync(addTagDto);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }
		
		[HttpDelete("[action]")]
		public async Task<IActionResult> RemoveTagAsync(int id)
		{
			await _tagService.RemoveTagAsync(id);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }
		
    }
}
