using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ApartmentRepository : IApartmentRepository
{
    private readonly IApplicationDbContext _context;

    public ApartmentRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Apartment>> GetUnsentAsync()
    {
        return await _context.Apartments.AsNoTracking().Where(x => !x.IsSent).ToListAsync();
    }

    public async Task<Apartment?> GetByIdAndPlatformAsync(long id, string platform)
    {
        return await _context.Apartments.FindAsync(id, platform);
    }

    public async Task<bool> IsExistsAsync(long id, string platform)
    {
        return await GetByIdAndPlatformAsync(id, platform) is not null;
    }

    public async Task<Apartment> AddAsync(Apartment apartment)
    {
        var created = await _context.Apartments.AddAsync(apartment);
        await _context.SaveChangesAsync(CancellationToken.None);
        return created.Entity;
    }

    public async Task UpdateAsync(Apartment apartment)
    {
        _context.Apartments.Update(apartment);
        await _context.SaveChangesAsync(CancellationToken.None);
    }
}
