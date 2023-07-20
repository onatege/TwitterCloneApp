using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository;

namespace TwitterCloneApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TweetController : ControllerBase
	{
		private readonly AppDbContext _context;
        public TweetController(AppDbContext context)
        {
			_context = context;
		}
        [HttpGet]
		public async Task<IActionResult> GetAllTweets()
		{
			var tweets = await _context.Tweets.ToListAsync();
			return Ok(tweets);
		}
		[HttpPost]
		public async Task<IActionResult> NewTweet()
		{
			var tweet = new Tweet
			{	
					isMainTweet = true,
					UserId = 1,
					Content = "Testing tweet"	
			};


			await _context.AddAsync(tweet);
			await _context.SaveChangesAsync();	
			return Ok(tweet);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetTweetById(int id)
		{
			await _context.Tweets.FindAsync(id);
			return Ok();
		}

		[HttpPut("{id}")]

		public async Task<IActionResult> UpdateTweet(int id, Tweet updatedTweet)
		{
			var tweet = await _context.Tweets.FindAsync(id);

			if(tweet != null)
			{

				if(tweet.IsDeleted)
				{
					tweet.DeletedAt = DateTime.Now;
					tweet.DeletedAt = updatedTweet.DeletedAt;
				}

				updatedTweet.UpdatedAt = DateTime.Now;
				tweet.Content = updatedTweet.Content;


				_context.Update(tweet);
				await _context.SaveChangesAsync();

				return Ok(tweet);
			}
			return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveTweet(int id)
		{
			var tweet = await _context.Tweets.FindAsync(id);

			if (tweet is null)
			{ 
				return NotFound(); 
			}

			if(tweet.IsDeleted == false)
			{
				tweet.IsDeleted = true;
				tweet.DeletedAt = DateTime.Now;
				_context.Update(tweet);
				await _context.SaveChangesAsync();
			}
			_context.Tweets.Remove(tweet);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
