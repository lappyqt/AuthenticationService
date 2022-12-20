using System.Linq.Expressions;
using AuthenticationService.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.DAL.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected DatabaseContext _context;
    protected DbSet<TEntity> _dbSet;

    public BaseRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
         =>  await _dbSet.Where(filter).ToListAsync();

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(filter);
        if (entity == null) throw new NullReferenceException();
        return entity;
    }

    public async Task<TEntity> RemoveAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}