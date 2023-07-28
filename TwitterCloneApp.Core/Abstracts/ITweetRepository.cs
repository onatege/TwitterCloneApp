using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Response.Tweet;

namespace TwitterCloneApp.Core.Abstracts
{
    public interface ITweetRepository : IGenericRepository<Tweet>
	{
		Task<List<Tweet>> GetTweets();
		Task<List<TweetResponseDto>> GetUserTweetsWithLikeCountAsync(int id);
		Task<List<TweetResponseDto>> GetTagTweetsWithLikeCountAsync(int id);
		Task AddTagToTweetAsync(int tweetId, int tagId);
		Task<Tweet> GetTweetByIdAsync(int tweetId);
    }
}
