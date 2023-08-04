using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TwitterCloneApp.Caching.Abstracts;
using TwitterCloneApp.Caching.Keys;
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
        private readonly ICacheService _cacheService;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, ITweetRepository tweetRepository, ICacheService cacheService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tweetRepository = tweetRepository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task AddUserAsync(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<GetUserProfileDto> FindUserByIdAsync(int id)
        {
            string cacheKey = string.Format(ConstantCacheKeys.UserKey, id);
            if (await _cacheService.AnyAsync(cacheKey))
            {
                var userCache = await _cacheService.GetAsync<User>(cacheKey);
                var userCacheDto = _mapper.Map<GetUserProfileDto>(userCache);
                var (followersForCached, followingForCached) = await _userRepository.GetUserFollowsByIdAsync(id);
                userCacheDto.FollowerCount = followersForCached?.Count ?? 0;
                userCacheDto.FollowingCount = followingForCached?.Count ?? 0;
                userCacheDto.Tweets = await _tweetRepository.GetUserTweetsWithLikeCountAsync(id);
                return userCacheDto;
            }

            var user = await _userRepository.FindUserByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException($"UserId({id}) not found!");
            }
            await _cacheService.SetAsync(cacheKey, user, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
            var userDto = _mapper.Map<GetUserProfileDto>(user);
            var (followers, following) = await _userRepository.GetUserFollowsByIdAsync(id);
            userDto.FollowerCount = followers?.Count ?? 0;
            userDto.FollowingCount = following?.Count ?? 0;
            userDto.Tweets = await _tweetRepository.GetUserTweetsWithLikeCountAsync(id);
            return userDto;
        }

        public async Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            string cacheKey = string.Format(ConstantCacheKeys.UserKey, id);

            if (await _cacheService.AnyAsync(cacheKey))
            {
                var userCache = await _cacheService.GetAsync<User>(cacheKey);
                userCache.UserName = updateUserDto.UserName;
                userCache.DisplayName = updateUserDto.DisplayName;
                userCache.Email = updateUserDto.Email;
                userCache.Biography = updateUserDto.Biography;
                userCache.ProfileImg = updateUserDto.ProfileImg;

                _userRepository.Update(userCache);
                await _unitOfWork.CommitAsync();
                await _cacheService.SetAsync(cacheKey, userCache, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
                var userExists = _mapper.Map<UpdateUserDto>(userCache);
                return userExists;
            }
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
            await _cacheService.SetAsync(cacheKey, user, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
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
