using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> GetUnsentAsync();
        Task<Apartment?> GetByIdAndPlatformAsync(long id, string platform);
        Task<bool> IsExistsAsync(long id, string platform);
        Task<Apartment> AddAsync(Apartment apartment);
        Task UpdateAsync(Apartment apartment);
    }
}
