namespace Application.Common.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TKey id);
    }
}
