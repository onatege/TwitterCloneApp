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
            if (await _userRepository.AnyAsync(u => u.UserName == addUserDto.UserName || u.Email == addUserDto.Email))
            {
                throw new BadRequestException($"User with ({addUserDto.UserName}) or ({addUserDto.Email}) exists.");
            }
            var user = _mapper.Map<User>(addUserDto);
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
            string cacheKey = string.Format(ConstantCacheKeys.UserKey, user.Id);
            await _cacheService.SetAsync(cacheKey, user, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
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
            else if (await _userRepository.AnyAsync(u => u.Id == id))
            {
                var user = await _userRepository.FindUserByIdAsync(id);
                await _cacheService.SetAsync(cacheKey, user, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
                var userDto = _mapper.Map<GetUserProfileDto>(user);
                var (followers, following) = await _userRepository.GetUserFollowsByIdAsync(id);
                userDto.FollowerCount = followers?.Count ?? 0;
                userDto.FollowingCount = following?.Count ?? 0;
                userDto.Tweets = await _tweetRepository.GetUserTweetsWithLikeCountAsync(id);
                return userDto;
            }
            throw new NotFoundException($"UserId({id}) not found!");
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

                _userRepository.UpdateAsync(userCache);
                await _unitOfWork.CommitAsync();
                await _cacheService.SetAsync(cacheKey, userCache, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
                var cachedUser = _mapper.Map<UpdateUserDto>(userCache);
                return cachedUser;
            }
            else if (await _userRepository.AnyAsync(u => u.Id == id))
            {
                var user = await _userRepository.FindUserByIdAsync(id);
                user.UserName = updateUserDto.UserName;
                user.DisplayName = updateUserDto.DisplayName;
                user.Email = updateUserDto.Email;
                user.Biography = updateUserDto.Biography;
                user.ProfileImg = updateUserDto.ProfileImg;
                _userRepository.UpdateAsync(user);
                await _unitOfWork.CommitAsync();
                await _cacheService.SetAsync(cacheKey, user, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
                var userDto = _mapper.Map<UpdateUserDto>(user);
                return userDto;
            }
                throw new NotFoundException($"UserId({id}) not found!");
        }

        public async Task DeactivateUserAsync(int userId)
        {
            string cacheKey = string.Format(ConstantCacheKeys.UserKey, userId);
            if (await _cacheService.AnyAsync(cacheKey))
            {
                var userCached = await _cacheService.GetAsync<User>(cacheKey);
                userCached.IsActive = false;
                _userRepository.UpdateAsync(userCached);
                await _unitOfWork.CommitAsync();
                await _cacheService.RemoveAsync(cacheKey);
            }
            else if (await _userRepository.AnyAsync(u => u.Id == userId))
            {
                var user = await _userRepository.ActivateUserAsync(userId);
                user.IsActive = false;
                _userRepository.UpdateAsync(user);
                await _unitOfWork.CommitAsync();
            }
                throw new NotFoundException($"UserId({userId}) not found!");
        }

        public async Task ActivateUserAsync(int userId)
        {
            string cacheKey = string.Format(ConstantCacheKeys.UserKey, userId);
            if (await _cacheService.AnyAsync(cacheKey))
            {
                var userCached = await _cacheService.GetAsync<User>(cacheKey);
                userCached.IsActive = true;
                _userRepository.UpdateAsync(userCached);
                await _unitOfWork.CommitAsync();
            }
            else if (await _userRepository.AnyAsync(u => u.Id == userId))
            {
                var user = await _userRepository.ActivateUserAsync(userId);
                user.IsActive = true;
                _userRepository.UpdateAsync(user);
                await _unitOfWork.CommitAsync();
                await _cacheService.SetAsync(cacheKey, user, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(2));
            }
            throw new NotFoundException($"UserId({userId}) not found!");
            
        }

        public async Task RemoveUserAsync(int id)
        {
            var cacheKey = string.Format(ConstantCacheKeys.UserKey, id);
            if (await _cacheService.AnyAsync(cacheKey)) 
            {
                var userCached = await _cacheService.GetAsync<User>(cacheKey);
                await _cacheService.RemoveAsync(cacheKey);
                _userRepository.Remove(userCached);
                await _unitOfWork.CommitAsync();
            }
            else if (await _userRepository.AnyAsync(u => u.Id == id))
            {
                var user = await _userRepository.GetByIdAsync(id);
                _userRepository.Remove(user);
                await _unitOfWork.CommitAsync();
            }
            throw new NotFoundException($"UserId({id}) not found!");
        }
    }
}
