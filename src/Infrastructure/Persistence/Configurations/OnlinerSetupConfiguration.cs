using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class OnlinerSetupConfiguration : IEntityTypeConfiguration<OnlinerSetup>
{
    public void Configure(EntityTypeBuilder<OnlinerSetup> builder)
    {
        builder.HasKey(x => x.ChatId);
        builder.Property(x => x.ChatId).ValueGeneratedNever();
    }
}
