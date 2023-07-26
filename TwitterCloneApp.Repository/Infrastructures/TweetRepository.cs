using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Tweet;
using TwitterCloneApp.Repository.Migrations;

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

		public async Task<List<TweetResponseDto>> GetUserTweetsWithLikeCountAsync(int id)
        {
            var tweets = await _context.Tweets.Where(u => u.UserId == id)
                .Select(t => new TweetResponseDto
                {
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    LikeCount = t.Likes != null ? t.Likes.Count : 0
                })
                .ToListAsync();

            return tweets;
        }

        public async Task<List<TweetResponseDto>> GetTagTweetsWithLikeCountAsync(int id)
        {
            var tagTweets = await _context.Tweets
                .Where(t => t.Tags.Any(tag => tag.Id == id))
                .Select(t => new TweetResponseDto
                {
                    Content = t.Content,
                    CreatedAt = t.CreatedAt,
                    LikeCount = t.Likes != null ? t.Likes.Count : 0
                })
                .ToListAsync();

            return tagTweets;
        }



    }
}
