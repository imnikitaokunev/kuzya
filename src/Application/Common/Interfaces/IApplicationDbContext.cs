using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Apartment> Apartments { get; }
        DbSet<Subscription> Subscriptions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
