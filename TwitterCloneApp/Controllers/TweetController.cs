using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.Tweet;
using TwitterCloneApp.DTO.Response;

namespace TwitterCloneApp.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class TweetController : ControllerBase
	{
		private readonly ITweetService _tweetService;
		public TweetController(ITweetService tweetService)
		{

			_tweetService = tweetService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllTweetAsync()
        {
			var tweets = await _tweetService.GetAllTweetAsync();
            return Ok(CustomResponseDto.Success(tweets, HttpStatusCode.OK));
        }

		[HttpPost]
		public async Task<IActionResult> AddTweetAsync(AddTweetDto addTweetDto)
		{
			await _tweetService.AddTweetAsync(addTweetDto);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }
		[HttpGet("[action]")]
		public async Task<IActionResult> GetTweetByIdAsync(int id)
		{
			var tweet = await _tweetService.GetTweetByIdAsync(id);
            return Ok(CustomResponseDto.Success(tweet, HttpStatusCode.OK));
        }

		[HttpDelete("[action]")]
		public async Task<IActionResult> RemoveTweetAsync(int id)
		{
			await _tweetService.RemoveTweetAsync(id);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }

		[HttpPut("[action]")]
		public async Task<IActionResult> AddTagToTweetAsync(int tweetId, int tagId)
		{
			await _tweetService.AddTagToTweetAsync(tweetId, tagId);
            return Ok(CustomResponseDto.Success(null, HttpStatusCode.OK));
        }

	}
}
