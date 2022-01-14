using Application.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        MappingProfile.ApplyMappings();

        services.AddHostedService<OnlinerWorker>();

        return services;
    }
}
