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
		private readonly IUnitOfWork _unitOfWork;
        public UserRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _user = context.Set<User>();
			_unitOfWork = unitOfWork;
		}

		public async Task<User> FindUserByIdAsync(int id)
		{
            var user = await _user.Include(u => u.Followers).Include(u => u.Following).Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
		}
        //.Include(u => u.Followers).Include(u => u.Following)
        public async Task<User> UpdateUserAsync(User user)
		{
			_user.Update(user);
			return user;
		}
		
	}
}
