using Application.Common;
using Application.Models;
using Application.Onliner;
using Domain.Entities;
using Mapster;

namespace Application;

internal static class MappingProfile
{
    public static void ApplyMappings()
    {
        TypeAdapterConfig<OnlinerApartmentDto, Apartment>
            .NewConfig()
            .Map(dst => dst.Platform, src => Constants.Onliner);

        TypeAdapterConfig<OnlinerApartmentDto, ApplicationApartment>
            .NewConfig()
            .Map(dst => dst.Amount, src => src.Price.Converted.USD.Amount)
            .Map(dst => dst.Currency, src => src.Price.Converted.USD.Currency)
            .Map(dst => dst.Platform, src => Constants.Onliner);
    }
}
