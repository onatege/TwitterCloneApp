using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Tweet;

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

        public async Task<List<TweetResponseDto>> GetUserTweetsWithLikeCount(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                return new List<TweetResponseDto>();
            }

            var tweets = await _context.Tweets
                .Where(t => t.UserId == user.Id)
                .Select(t => new TweetResponseDto
                {
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    LikeCount = t.Likes != null ? t.Likes.Count : 0
                })
                .ToListAsync();

            return tweets;
        }

    }
}
