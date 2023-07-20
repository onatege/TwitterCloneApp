using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Tweet;

namespace TwitterCloneApp.Service.Concrete
{
	public class TweetService : Service<Tweet>, ITweetService
	{
		private readonly ITweetService _tweetService;
		public TweetService(IGenericRepository<Tweet> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
		{

		}

		public async Task<List<TweetDto>> GetAllTweetsAsync()
		{
			return await _tweetService.GetAllTweetsAsync();
		}
	}
}