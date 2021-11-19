using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IChatRepository : IRepository<Chat, long>
{
}
