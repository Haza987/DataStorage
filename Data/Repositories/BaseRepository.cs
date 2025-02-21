using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class BaseRepository<TEntity>(DbContext context, IMemoryCache cache) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    protected readonly IMemoryCache _cache = cache;
    private IDbContextTransaction _transaction = null!;

    private string GetCacheKey(string methodName, object? key = null) =>
        $"{typeof(TEntity).Name}_{methodName}_{key}";

    #region Transaction management

    public virtual async Task BeginTransactionAsync()
    {
        if (_transaction == null)
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
    }

    public virtual async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    #endregion

    #region CRUD Operations

    public async Task<bool> CreateAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            _cache.Remove(GetCacheKey(nameof(GetAllAsync)));
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Exception: {ex.Message}");
            return false;
        }
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        var cacheKey = GetCacheKey(nameof(GetAllAsync));

        if (_cache.TryGetValue(cacheKey, out IEnumerable<TEntity>? cachedEntities))
        {
            return cachedEntities;
        }

        var entities = await _dbSet.ToListAsync();

        _cache.Set(cacheKey, entities, TimeSpan.FromMinutes(5));

        return entities;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _dbSet.SingleOrDefaultAsync(expression);
        Debug.WriteLine(entity != null ? "Entity found in database" : "Entity not found in database");
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            _cache.Remove(GetCacheKey(nameof(GetAllAsync)));
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            _cache.Remove(GetCacheKey(nameof(GetAllAsync)));
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _dbSet.AnyAsync(expression);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    #endregion
}