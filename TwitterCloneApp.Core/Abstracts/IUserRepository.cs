using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByIdAsync(int id);
        Task<User> UpdateUserAsync(User user);
    }
}
