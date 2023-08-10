﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public async Task<User> GetUserForActivationAsync(int id)
        {
            var user = await  _user.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<bool> AnyDeactiveUserAsync(Expression<Func<User, bool>> expression)
        {
            return await _user.IgnoreQueryFilters().AnyAsync(expression);
        }

        public async Task<User> FindUserByIdAsync(int id)
		{
            var user = await _user.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
		}

        public async Task<User> GetUserWithFollowersByIdAsync(int userId)
        {
            var user = await _user.Where(u => u.Id == userId).Include(u => u.Followers).Include(u => u.Following).FirstOrDefaultAsync();
            return user;
        }


    }
}
