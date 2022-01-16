using Application.Common.Commands;
using Application.Workers;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        MappingProfile.ApplyMappings();

        services.AddTransient<ListCommand>();
        services.AddTransient<CommandsList>();

        services.AddHostedService<OnlinerWorker>();
        services.AddHostedService<SenderWorker>();
        services.AddHostedService<TelegramWorker>();

        return services;
    }
}
