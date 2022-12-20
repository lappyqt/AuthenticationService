using System.Linq.Expressions;

namespace AuthenticationService.DAL.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    public Task<TEntity> RemoveAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
}