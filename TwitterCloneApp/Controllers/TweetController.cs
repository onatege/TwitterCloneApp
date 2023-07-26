using Microsoft.AspNetCore.Mvc;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.DTO.Tweet;

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
			return Ok(tweets);
		}

		[HttpPost]
		public async Task<IActionResult> AddTweetAsync(AddTweetDto addTweetDto)
		{
			await _tweetService.AddTweetAsync(addTweetDto);
			return Ok();
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTweetByIdAsync(int id)
		{
			var tweet = await _tweetService.GetTweetByIdAsync(id);
			return Ok(tweet);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveTweet(int id)
		{
			var tweetId = await _tweetService.GetByIdAsync(id);
			_tweetService.Remove(tweetId);
			return Ok();
		}

	}
}
