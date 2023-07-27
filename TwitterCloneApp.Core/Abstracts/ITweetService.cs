﻿using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Tweet;

namespace TwitterCloneApp.Core.Abstracts
{
    public interface ITweetService : IService<Tweet>
	{
		Task AddTweetAsync(AddTweetDto addTweetDto);
		Task<TweetDto> GetTweetByIdAsync(int tweetId);
        Task<List<TweetDto>> GetAllTweetAsync();
		Task RemoveTweetAsync(int id);
		Task AddTagToTweetAsync(int id, int tagId);
    }
}
