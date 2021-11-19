using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.HasOne(x => x.OnlinerSetup).WithOne().HasForeignKey<OnlinerSetup>(x => x.ChatId);
    }
}
