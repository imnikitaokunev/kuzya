using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetByIdAndPlatformAsync(long id, string platform);
        Task<bool> IsExists(long id, string platform);
        Task<Apartment> AddAsync(Apartment apartment);
    }
}
