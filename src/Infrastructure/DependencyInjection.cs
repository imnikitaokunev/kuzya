using Application.Common.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseCosmos(configuration["CosmosDB:AccountEndpoint"], configuration["CosmosDB:AccountKey"], configuration["CosmosDB:DatabaseName"]),
                ServiceLifetime.Singleton
            );

            services.AddSingleton<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddSingleton<IApartmentRepository, ApartmentRepository>();

            return services;
        }
    }
}
