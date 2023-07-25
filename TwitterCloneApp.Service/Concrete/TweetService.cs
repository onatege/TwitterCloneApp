using AutoMapper;
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
	public class TweetService : ITweetService
	{
		private readonly ITweetRepository _tweetRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public TweetService(IUnitOfWork unitOfWork, ITweetRepository tweetRepository, IMapper mapper)
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

		
	}
}