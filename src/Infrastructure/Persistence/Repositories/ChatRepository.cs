using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ChatRepository : Repository<Chat, long>, IChatRepository
{
    protected override DbSet<Chat> DbSet => Context.Chats;

    public ChatRepository(IApplicationDbContext context) : base(context)
    {
    }
}
