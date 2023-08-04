using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByIdAsync(int id);
        Task<User> ActivateUserAsync(int id);
        Task<(ICollection<User> Followers, ICollection<User> Following)> GetUserFollowsByIdAsync(int userId);
    }
}
