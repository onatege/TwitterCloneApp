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
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserAsync(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

		public async Task<GetUserProfileDto> FindUserByIdAsync(int id)
		{
            var user = await _userRepository.FindUserByIdAsync(id);
            if (user != null) 
            {
                var userDto = _mapper.Map<GetUserProfileDto>(user);
                userDto.FollowerCount = user.Followers?.Count ?? 0;
                userDto.FollowingCount = user.Following?.Count ?? 0;
                userDto.Tweets = await _tweetRepository.GetUserTweetsWithLikeCountAsync(id);
                await _unitOfWork.CommitAsync();
                return userDto;
            }
            return null;
            
		}

        //public async Task SoftDeleteUserAsync(DeleteDto deleteUserDto)
        //{
        //    await _userRepository.SoftDeleteUserAsync(deleteUserDto);
        //}

   
        public async Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.FindUserByIdAsync(id);
            if (user != null)
            {
                user.UserName = updateUserDto.UserName;
                user.DisplayName = updateUserDto.DisplayName;
                user.Email = updateUserDto.Email;
                user.Biography = updateUserDto.Biography;
                user.ProfileImg = updateUserDto.ProfileImg;

                _userRepository.Update(user);
                await _unitOfWork.CommitAsync();
                var userDto = _mapper.Map<UpdateUserDto>(user);
                return userDto;
            }
            return null;
        }
    }
}
