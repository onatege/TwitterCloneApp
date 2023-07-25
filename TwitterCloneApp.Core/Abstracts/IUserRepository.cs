using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.DTO;
using TwitterCloneApp.DTO.Response;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Core.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByNameAsync(string userName);
        Task<User> UpdateUserAsync(User user);
    }
}
