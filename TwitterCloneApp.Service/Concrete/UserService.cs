using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.DTO.User;
using TwitterCloneApp.DTO;

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

        public async Task<UserDto> GetUserByUsernameAsync(UsernameDto getByUsernameDto)
        {
            return await _userRepository.GetUserByUsernameAsync(getByUsernameDto);
        }

        public async Task<UserDto> AddUserAsync(AddUserDto addUserDto)
        {
            return await _userRepository.AddUserAsync(addUserDto);
        }

        public async Task SoftDeleteUserAsync(DeleteDto deleteUserDto)
        {
            await _userRepository.SoftDeleteUserAsync(deleteUserDto);
        }

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            await _userRepository.UpdateUserAsync(updateUserDto);
        }
    }
}
