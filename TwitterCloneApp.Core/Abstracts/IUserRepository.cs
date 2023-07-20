using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByUsernameAsync(UsernameDto getByUsernameDto);
        Task<UserDto> AddUserAsync(AddUserDto addUserDto);
        Task SoftDeleteUserAsync(DeleteDto deleteUserDto);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
    }
}
