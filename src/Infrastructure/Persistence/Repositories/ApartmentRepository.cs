using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories;

public class ApartmentRepository : IApartmentRepository
{
    private readonly IApplicationDbContext _context;

    public ApartmentRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Apartment?> GetByIdAndPlatformAsync(long id, string platform)
    {
        return await _context.Apartments.FindAsync(id, platform);
    }

    public async Task<bool> IsExists(long id, string platform)
    {
        return await GetByIdAndPlatformAsync(id, platform) is not null;
    }

    public async Task<Apartment> AddAsync(Apartment apartment)
    {
        var created = await _context.Apartments.AddAsync(apartment);
        await _context.SaveChangesAsync(CancellationToken.None);
        return created.Entity;
    }
}
