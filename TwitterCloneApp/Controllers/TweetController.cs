using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Tweet;
using TwitterCloneApp.Repository;

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

		[HttpPost]
		public async Task<IActionResult> AddTweetAsync(AddTweetDto addTweetDto)
		{
			await _tweetService.AddTweetAsync(addTweetDto);
			return Ok();
		}
	}
}
