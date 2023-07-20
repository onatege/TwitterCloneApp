using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUsernameAsync(UsernameDto getByUsernameDto);
        Task<UserDto> AddUserAsync(AddUserDto addUserDto);
        Task SoftDeleteUserAsync(UsernameDto deleteUserDto);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
    }
}
