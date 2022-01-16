using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly IApplicationDbContext _context;

    public SubscriptionRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Subscription>> GetActiveAsync()
    {
        return await _context.Subscriptions.Where(x => x.IsActive).ToListAsync();
    }
}
