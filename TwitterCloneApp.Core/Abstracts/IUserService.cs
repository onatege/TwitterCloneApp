using TwitterCloneApp.DTO.Request.User;
using TwitterCloneApp.DTO.Response.User;

namespace TwitterCloneApp.Core.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(AddUserDto addUserDto);
        Task<GetUserProfileDto> FindUserByIdAsync(int id);
        //Task SoftDeleteUserAsync(DeleteDto deleteUserDto);
        Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    }
}
