﻿using System.Linq.Expressions;
using TwitterCloneApp.Core.Abstracts;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByIdAsync(int id);
        Task<User> GetUserForActivationAsync(int id);
        Task<User> GetUserWithFollowersByIdAsync(int userId);
        Task<bool> AnyDeactiveUserAsync(Expression<Func<User, bool>> expression);
    }
}
