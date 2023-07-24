using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Response;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Core.Interfaces
{
    public interface IUserService
    {
        //Task<GetUserProfileDto> GetUserProfileAsync(string username);
        Task AddUserAsync(AddUserDto addUserDto);
        Task<GetUserProfileDto> FindUserByNameAsync(UserNameDto userNameDto);
		//Task SoftDeleteUserAsync(DeleteDto deleteUserDto);
  //      Task UpdateUserAsync(UpdateUserDto updateUserDto);
    }
}
