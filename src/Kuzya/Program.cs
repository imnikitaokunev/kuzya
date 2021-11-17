using Application;
using Application.Models.Options;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, configuration) =>
        {
            configuration.Sources.Clear();

            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddEnvironmentVariables();

            var env = hostingContext.HostingEnvironment.EnvironmentName;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment != null)
            {
                configuration.AddJsonFile($"appsettings.{environment}.json", true, true);
            }
        })
        .ConfigureServices((context, services) =>
        {
            var configurationRoot = context.Configuration;

            services.Configure<OnlinerOptions>(
                configurationRoot.GetSection(nameof(OnlinerOptions)));

            //var options = new TelegramOptions();
            //configurationRoot.GetSection(nameof(TelegramOptions)).Bind(options);

            //services.AddTransient<ITelegramBotClient>(x => new TelegramBotClient(options.ApiKey));
            //services.AddTransient<TelegramReceiever>();

            services.AddApplication();
            services.AddInfrastructure(configurationRoot);
        });
}
