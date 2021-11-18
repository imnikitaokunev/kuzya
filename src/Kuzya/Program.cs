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

            var environment = hostingContext.HostingEnvironment.EnvironmentName;
            configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{environment}.json", true, true)
                         .AddEnvironmentVariables();
        })
        .ConfigureServices((context, services) =>
        {
            var configurationRoot = context.Configuration;

            services.Configure<OnlinerOptions>(
                configurationRoot.GetSection(nameof(OnlinerOptions)));

            services.Configure<ApplicationOptions>(
                configurationRoot.GetSection(nameof(ApplicationOptions)));

            //var options = new TelegramOptions();
            //configurationRoot.GetSection(nameof(TelegramOptions)).Bind(options);

            //services.AddTransient<ITelegramBotClient>(x => new TelegramBotClient(options.ApiKey));
            //services.AddTransient<TelegramReceiever>();

            services.AddApplication(configurationRoot);
            services.AddInfrastructure(configurationRoot);
        });
}
