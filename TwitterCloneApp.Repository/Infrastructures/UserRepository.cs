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
            var user = await _user.Include(u => u.Followers).Include(u => u.Following).Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
		}
        //.Include(u => u.Followers).Include(u => u.Following)

		
	}
}
