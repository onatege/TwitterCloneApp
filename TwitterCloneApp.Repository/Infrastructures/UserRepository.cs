using Microsoft.EntityFrameworkCore;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Interfaces;
using TwitterCloneApp.Core.Models;
using TwitterCloneApp.Repository.Infrastructures;

namespace TwitterCloneApp.Repository.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _user;
        public UserRepository(AppDbContext context) : base(context)
        {
            _user = context.Set<User>();
		}

        public async Task<User> ActivateUserAsync(int id)
        {
            var user = await  _user.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> FindUserByIdAsync(int id)
		{
            var user = await _user.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
		}

        public async Task<(ICollection<User> Followers, ICollection<User> Following)> GetUserFollowsByIdAsync(int userId)
        {
            var result = await _user
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    Followers = u.Followers,
                    Following = u.Following
                })
                .FirstOrDefaultAsync();

            return (result.Followers, result.Following);
        }


    }
}
