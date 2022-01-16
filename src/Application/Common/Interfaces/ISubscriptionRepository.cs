using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Subscription>> GetActiveAsync();
    Task<IEnumerable<Subscription>> GetActiveByChatIdAsync(long chatId);
}
