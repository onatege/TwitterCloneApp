using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Tweet;

namespace TwitterCloneApp.Core.Abstracts
{
	public interface ITweetRepository : IGenericRepository<Tweet>
	{
		Task<List<Tweet>> GetTweets();
		Task<List<TweetResponseDto>> GetUserTweetsWithLikeCount(string userName);
    }
}
