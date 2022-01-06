using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<OnlinerApartment>? OnlinerApartments { get; }
        DbSet<Chat>? Chats { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
