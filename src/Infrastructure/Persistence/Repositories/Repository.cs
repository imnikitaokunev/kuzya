using System.Linq.Expressions;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity
{
    protected readonly IApplicationDbContext Context;
    protected abstract DbSet<TEntity> DbSet { get; }

    protected Repository(IApplicationDbContext context)
    {
        Context = context;
    }

    public virtual async Task<List<TEntity>> GetAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var created = await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync(CancellationToken.None);
        return created.Entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync(CancellationToken.None);
    }
}
