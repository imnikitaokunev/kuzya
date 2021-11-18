using Application.Onliner;
using Domain.Entities;
using Mapster;

namespace Application;

internal static class MappingProfile
{
    public static void ApplyMappings()
    {
        TypeAdapterConfig<OnlinerApartmentDto, OnlinerApartment>
            .NewConfig();
    }
}
