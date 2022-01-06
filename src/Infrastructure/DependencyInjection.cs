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
                options.UseCosmos(configuration["CosmosDb:AccountEndpoint"], configuration["CosmosDb:AccountKey"], configuration["CosmosDb:DatabaseName"])
            );

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IOnlinerApartmentRepository, OnlinerApartmentRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();

            return services;
        }
    }
}
