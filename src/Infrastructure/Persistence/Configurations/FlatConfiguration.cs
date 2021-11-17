using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<FlatEntity>
    {
        public void Configure(EntityTypeBuilder<FlatEntity> builder)
        {
            builder.ToTable("Flats");

            builder.HasKey(x => new { x.Id, x.Site });
        }
    }
}
