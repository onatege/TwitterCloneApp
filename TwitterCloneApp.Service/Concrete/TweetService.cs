using AutoMapper;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.Tweet;
using TwitterCloneApp.DTO.Response.Reply;
using TwitterCloneApp.DTO.Response.Tag;
using TwitterCloneApp.DTO.Response.Tweet;
using TwitterCloneApp.DTO.Response.User;

namespace TwitterCloneApp.Service.Concrete
{
    public class TweetService : Service<Tweet>, ITweetService
	{
		private readonly ITweetRepository _tweetRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public TweetService(IGenericRepository<Tweet> repository, IUnitOfWork unitOfWork, ITweetRepository tweetRepository, IMapper mapper, ITagRepository tagRepository) : base(repository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tweetRepository = tweetRepository;
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task AddTweetAsync(AddTweetDto addTweetDto)
		{
			var tweet = _mapper.Map<Tweet>(addTweetDto);
			await _tweetRepository.AddAsync(tweet);
			await _unitOfWork.CommitAsync();
		}

        public async Task<TweetDto> GetTweetByIdAsync(int tweetId)
        {
            var tweet = await _tweetRepository.GetTweetByIdAsync(tweetId);

            if (tweet == null)
            {
                throw new NotFoundException($"TweetId({tweetId}) not found.");
            }

            var tweetDto = new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                CreatedAt = tweet.CreatedAt,
                LikeCount = tweet.Likes?.Count ?? 0,
                Tags = tweet.Tags?.Select(t => new TagResponseDto
                {
                    Name = t.Name
                }).ToList(),
                User = new UserResponseDto
                {
                    UserName = tweet.User.UserName,
                    DisplayName = tweet.User.DisplayName,
                    ProfileImg = tweet.User.ProfileImg
                },
                Replies = tweet.Replies?.Select(reply => new ReplyResponseDto
                {
                    User = new UserResponseDto
                    {
                        UserName = reply.User.UserName,
                        DisplayName = reply.User.DisplayName,
                        ProfileImg = reply.User.ProfileImg
                    },
                    Content = reply.Content,
                    CreatedAt = reply.CreatedAt
                }).ToList()
            };

            return tweetDto;
        }


        public async Task<List<TweetDto>> GetAllTweetAsync()
		{
			var tweet = await _tweetRepository.GetTweets();
			var tweetDto = _mapper.Map<List<TweetDto>>(tweet);
			return tweetDto;
		}

		public async Task RemoveTweetAsync(int id)
		{
			var tweet = await _tweetRepository.GetByIdAsync(id);
            if(tweet == null)
            {
                throw new NotFoundException($"TweetId({id}) not found.");
            }
			_tweetRepository.Remove(tweet);
			await _unitOfWork.CommitAsync();
		}

        public async Task AddTagToTweetAsync(int tweetId, int tagId)
        {
            await _tweetRepository.AddTagToTweetAsync(tweetId, tagId);
            await _unitOfWork.CommitAsync();
        }
    }
}