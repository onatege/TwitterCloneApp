using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Core.Interfaces
{
	public interface IUserService
    {
        Task AddUserAsync(AddUserDto addUserDto);
        Task<GetUserProfileDto> FindUserByNameAsync(UserNameDto userNameDto);
        //Task SoftDeleteUserAsync(DeleteDto deleteUserDto);
        Task<UpdateUserDto> UpdateUserAsync(string userName, UpdateUserDto updateUserDto);
    }
}
