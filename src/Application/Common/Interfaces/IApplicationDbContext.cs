using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<OnlinerApartment> OnlinerApartments { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
