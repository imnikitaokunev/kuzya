using Application.Common;
using Application.Common.Interfaces;
using Application.Jobs;
using Application.Models.Options;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        MappingProfile.ApplyMappings();

        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddQuartz(q =>
        {
            q.SchedulerId = "Scheduler-Core";

            q.UseMicrosoftDependencyInjectionJobFactory();
            q.UseSimpleTypeLoader();
            q.UseInMemoryStore();
            q.UseDefaultThreadPool(tp =>
            {
                tp.MaxConcurrency = 10;
            });

            var applicationOptions = new ApplicationOptions();
            configuration.GetSection(nameof(ApplicationOptions)).Bind(applicationOptions);

            q.UseJobFactory<JobFactory>();

            q.ScheduleJob<OnlinerJob>(trigger => trigger
                .WithIdentity("Onliner Trigger")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInMinutes(applicationOptions.Interval).RepeatForever())
                .WithDescription("Repeat every [interval] minutes forever")
            );
        });

        services.AddTransient<OnlinerJob>();
        services.AddTransient<IChatNotifier, ChatNotifier>();
        services.AddScoped<TelegramReceiver>();

        // Quartz.Extensions.Hosting allows you to fire background service that handles scheduler lifecycle
        services.AddQuartzHostedService(options =>
        {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
        });

        return services;
    }
}
