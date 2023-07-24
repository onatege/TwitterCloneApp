using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Core.Interfaces
{
    public interface IUserService
    {
        Task<GetUserProfileDto> GetUserByUsernameAsync(UsernameDto getByUsernameDto);
        Task<UserDto> AddUserAsync(AddUserDto addUserDto);
        Task SoftDeleteUserAsync(DeleteDto deleteUserDto);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
    }
}
