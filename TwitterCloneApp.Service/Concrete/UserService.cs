using AutoMapper;
using System.Net;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Response;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Service.Concrete
{
	public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            var userDto = _mapper.Map<GetUserProfileDto>(user);
            return userDto;
		}

		//public async Task SoftDeleteUserAsync(DeleteDto deleteUserDto)
		//{
		//    await _userRepository.SoftDeleteUserAsync(deleteUserDto);
		//}

		//public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
		//{
		//    await _userRepository.UpdateUserAsync(updateUserDto);
		//}
	}
}
