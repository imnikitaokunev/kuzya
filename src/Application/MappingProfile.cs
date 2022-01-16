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
            .Map(dst => dst.Platform, src => Constants.Onliner)
            .Map(dst => dst.Rooms, src => ParseRooms(src.RentType))
            .Map(dst => dst.Link, src => src.Url)
            .Map(dst => dst.Price, src => src.Price.Converted.BYN.Amount)
            .Map(dst => dst.Currency, src => Constants.OnlinerCurrency)
            .Map(dst => dst.UsdPrice, src => src.Price.Converted.USD.Amount)
            .Map(dst => dst.IsOwner, src => src.Contact.Owner)
            .Map(dst => dst.Address, src => src.Location.Address);

        TypeAdapterConfig<OnlinerApartmentDto, ApplicationApartment>
            .NewConfig()
            .Map(dst => dst.Platform, src => Constants.Onliner)
            .Map(dst => dst.Price, src => src.Price.Converted.BYN.Amount)
            .Map(dst => dst.Currency, src => Constants.OnlinerCurrency)
            .Map(dst => dst.Address, src => src.Location.Address);
    }

    private static int ParseRooms(string text)
    {
        return int.TryParse(text[..1], out var rooms) ? rooms : 1;
    }
}
