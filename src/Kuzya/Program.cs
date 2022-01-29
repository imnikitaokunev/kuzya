using Application;
using Application.Models.Options;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Kuzya;

public class Program
{
    public static async Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, configuration) =>
        {
            configuration.Sources.Clear();

            var environment = hostingContext.HostingEnvironment.EnvironmentName;
            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{environment}.json", true, true)
                         .AddEnvironmentVariables();
        })
        .UseSerilog((context, configuration) =>
        {
            configuration.Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .ReadFrom.Configuration(context.Configuration);
        })
        .ConfigureServices((context, services) =>
        {
            var configurationRoot = context.Configuration;

            services.Configure<OnlinerOptions>(
                configurationRoot.GetSection(OnlinerOptions.Onliner));

            services.Configure<ApplicationOptions>(
                configurationRoot.GetSection(ApplicationOptions.Application));

            services.AddApplication();
            services.AddInfrastructure(configurationRoot);
        });
}
