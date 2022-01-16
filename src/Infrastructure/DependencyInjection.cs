using Application.Common.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseCosmos(configuration["CosmosDB:AccountEndpoint"], configuration["CosmosDB:AccountKey"], configuration["CosmosDB:DatabaseName"]),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient
            );

            // Todo: Add checks for start.
            services.AddTransient<ITelegramBotClient>(x => new TelegramBotClient(configuration["Telegram:ApiToken"]));
            services.AddTransient<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IApartmentRepository, ApartmentRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<ITelegramService, TelegramService>();

            return services;
        }
    }
}
