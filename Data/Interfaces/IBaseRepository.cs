﻿using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<bool> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>?> GetAllAsync();
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
}
