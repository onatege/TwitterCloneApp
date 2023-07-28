﻿using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Response.Tweet;

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
            var tweet = await _tweet.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == tweetId);
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Id == tagId);

            if (tweet != null && tag != null)
            {
                tweet.Tags.Add(tag);
            }
        }
        public async Task<Tweet> GetTweetByIdAsync(int tweetId)
        {
            return await _tweet
                .Include(t => t.User)
                .Include(t => t.Tags)
                .Include(t => t.Likes)
                .Include(t => t.Replies).ThenInclude(reply => reply.User)
                .FirstOrDefaultAsync(t => t.Id == tweetId);
        }
    }
}
