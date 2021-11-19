using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<OnlinerApartment> OnlinerApartments { get; }
        DbSet<Chat> Chats { get; }
        DbSet<OnlinerSetup> OnlinerSetups { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
