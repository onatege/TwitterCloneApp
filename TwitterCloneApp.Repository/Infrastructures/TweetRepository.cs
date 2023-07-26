using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        private readonly DbSet<Tweet> _tweet;
        public TweetRepository(AppDbContext context) : base(context)
        {
            _tweet = context.Set<Tweet>();
        }

        public async Task<List<Tweet>> GetTweets()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task<List<TweetResponseDto>> GetUserTweetsWithLikeCountAsync(int id)
        {
            var tweets = await _tweet.Where(u => u.UserId == id)
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
            var tagTweets = await _tweet
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
        public async Task AddTagToTweetAsync(int tweetId, int tagId)
        {
            var tweet = await _context.Tweets.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == tweetId);
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == tagId);

            if (tweet != null && tag != null)
            {
                tweet.Tags.Add(tag);
            }
        }
        public async Task<Tweet> GetTweetWithTagsByIdAsync(int tweetId)
        {
            return await _tweet.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == tweetId);
        }
    }
}
