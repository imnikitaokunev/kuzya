using System.Linq.Expressions;

namespace Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}
