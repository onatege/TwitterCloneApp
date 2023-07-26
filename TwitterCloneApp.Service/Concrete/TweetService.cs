using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Tweet;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Service.Concrete
{
	public class TweetService : Service<Tweet>, ITweetService
	{
		private readonly ITweetRepository _tweetRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public TweetService(IGenericRepository<Tweet> repository, IUnitOfWork unitOfWork, ITweetRepository tweetRepository, IMapper mapper) : base (repository,unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_tweetRepository = tweetRepository;
			_mapper = mapper;
		}

		public async Task AddTweetAsync(AddTweetDto addTweetDto)
		{
			var tweet = _mapper.Map<Tweet>(addTweetDto);
			await _tweetRepository.AddAsync(tweet);
			await _unitOfWork.CommitAsync();
		}

		public async Task<TweetDto> GetTweetByIdAsync(int id)
		{
			var tweet = await _tweetRepository.GetByIdAsync(id);
			var tweetDto = _mapper.Map<TweetDto>(tweet);
			tweetDto.LikeCount = tweet.Likes?.Count ?? 0;
			return tweetDto;
		}

		public async Task<List<TweetDto>> GetAllTweetAsync()
		{
			var tweet = await _tweetRepository.GetTweets();
			var tweetDto = _mapper.Map<List<TweetDto>>(tweet);
			return tweetDto;
		}

		
	}
}