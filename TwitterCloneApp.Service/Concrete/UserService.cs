using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO.Request.User;
using TwitterCloneApp.DTO.Response.User;
using TwitterCloneApp.Service.Exceptions;

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
            if (user == null) 
            {
                throw new NotFoundException($"UserId({id}) not found!");
            }
			var userDto = _mapper.Map<GetUserProfileDto>(user);
			userDto.FollowerCount = user.Followers?.Count ?? 0;
			userDto.FollowingCount = user.Following?.Count ?? 0;
			userDto.Tweets = await _tweetRepository.GetUserTweetsWithLikeCountAsync(id);
			await _unitOfWork.CommitAsync();
			return userDto;
 
		}

        public async Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.FindUserByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException($"UserId({id}) not found!");
            }
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

        public async Task DeactivateUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId); 
            if (user != null)
            {
                user.IsActive = false;
            }
            else
            {
                throw new NotFoundException($"UserId({userId}) not found!");
            }
            await _unitOfWork.CommitAsync();
        }

        public async Task ActivateUserAsync(int userId)
        {
            var user = await _userRepository.ActivateUserAsync(userId);
            if (user != null)
            {
                user.IsActive = true;
            }
            else
                throw new NotFoundException($"UserId({userId}) not found!");
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException($"UserId({id}) not found!");
            }
            _userRepository.Remove(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
