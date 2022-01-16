using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Subscription>> GetActiveAsync();
}
