using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal class OnlinerApartmentConfiguration : IEntityTypeConfiguration<OnlinerApartment>
{
    public void Configure(EntityTypeBuilder<OnlinerApartment> builder)
    {
        builder.ToContainer(nameof(OnlinerApartment));
        builder.HasNoDiscriminator();
    }
}
