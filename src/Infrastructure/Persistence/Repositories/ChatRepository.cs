using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories;

public class ChatRepository : Repository<Chat, long>, IChatRepository
{
    protected override DbSet<Chat> DbSet => Context.Chats;

    public ChatRepository(IApplicationDbContext context) : base(context)
    {
    }

    public override async Task<List<Chat>> GetAsync(Expression<Func<Chat, bool>> predicate)
    {
        return await DbSet.Include(x => x.OnlinerSetup).Where(predicate).ToListAsync();
    }
}
