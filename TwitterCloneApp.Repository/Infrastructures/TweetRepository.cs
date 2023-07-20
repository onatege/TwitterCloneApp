using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Repository.Infrastructures
{
	public class TweetRepository : GenericRepository<Tweet>, ITweetRepository
	{
		public TweetRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<List<Tweet>> GetTweets()
		{
			return await _context.Tweets.ToListAsync();
		}
	}
}
