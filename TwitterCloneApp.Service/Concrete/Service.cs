﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TwitterCloneApp.Core.Abstracts;

namespace TwitterCloneApp.Service.Concrete
{
	public class Service<T> : IService<T> where T : class
	{
		private readonly IGenericRepository<T> _repository;
		private readonly IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _repository.AddAsync(entity);
			await _unitOfWork.CommitAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
		{
			await _repository.AddRangeAsync(entities);
			await _unitOfWork.CommitAsync();
			return entities;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await _repository.AnyAsync(expression);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _repository.GetAll().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task Remove(T entity)
		{
			_repository.Remove(entity);
			await _unitOfWork.CommitAsync();
		}

		public async Task RemoveRange(IEnumerable<T> entities)
		{
			_repository.RemoveRange(entities);
			await _unitOfWork.CommitAsync();

		}

		public async Task UpdateAsync(T entity)
		{
			_repository.UpdateAsync(entity);
			await _unitOfWork.CommitAsync();

		}

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return _repository.Where(expression);
		}
	}
}
