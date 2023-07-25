using AutoMapper;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Service.Concrete
{
	public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITweetRepository _tweetRepository;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, ITweetRepository tweetRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tweetRepository = tweetRepository;
        }

        //public async Task<GetUserProfileDto> GetUserProfileAsync(string username) //Task, await, async ilişkisi!!
        //{
        //    var user = _userRepository.GetUserProfileAsync(username);
        //    var userDto = _mapper.Map<GetUserProfileDto>(user);
        //    return userDto;
        //}

        public async Task AddUserAsync(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            await _userRepository.AddAsync(user);
            
        }

		public async Task<GetUserProfileDto> FindUserByNameAsync(UserNameDto userNameDto)
		{
            var user = await _userRepository.FindUserByNameAsync(userNameDto.UserName);
            if (user != null) 
            {
                var userDto = _mapper.Map<GetUserProfileDto>(user);
                userDto.FollowerCount = user.Followers?.Count ?? 0;
                userDto.FollowingCount = user.Following?.Count ?? 0;
                userDto.Tweets = await _tweetRepository.GetUserTweetsWithLikeCount(userNameDto.UserName);
                return userDto;
            }
            return null;
            
		}

        //public async Task SoftDeleteUserAsync(DeleteDto deleteUserDto)
        //{
        //    await _userRepository.SoftDeleteUserAsync(deleteUserDto);
        //}

   
        public async Task<UpdateUserDto> UpdateUserAsync(string userName, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.FindUserByNameAsync(userName);
            if (user != null)
            {
                user.UserName = updateUserDto.UserName;
                user.DisplayName = updateUserDto.DisplayName;
                user.Email = updateUserDto.Email;
                user.Biography = updateUserDto.Biography;
                user.ProfileImg = updateUserDto.ProfileImg;

                await _userRepository.UpdateUserAsync(user);
                var userDto = _mapper.Map<UpdateUserDto>(user);
                return userDto;
            }
            return null;
        }
    }
}
