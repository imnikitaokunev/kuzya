using Application;
using Application.Common;
using Application.Models.Options;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Telegram.Bot;

public class Program
{
    public static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        var receiever = host.Services.CreateScope().ServiceProvider.GetRequiredService<TelegramReceiver>();
        receiever?.Start();

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
                .ReadFrom.Configuration(context.Configuration);

            if (context.HostingEnvironment.IsDevelopment())
            {
                configuration.WriteTo.File("log.txt");
            }
        })
        .ConfigureServices((context, services) =>
        {
            var configurationRoot = context.Configuration;

            services.Configure<OnlinerOptions>(
                configurationRoot.GetSection(nameof(OnlinerOptions)));

            services.Configure<ApplicationOptions>(
                configurationRoot.GetSection(nameof(ApplicationOptions)));

            var telegramOptions = new TelegramOptions();
            configurationRoot.GetSection(nameof(TelegramOptions)).Bind(telegramOptions);

            services.Configure<TelegramOptions>(
                configurationRoot.GetSection(nameof(TelegramOptions)));

            services.AddTransient<ITelegramBotClient>(x => new TelegramBotClient(telegramOptions.ApiToken));

            services.AddApplication(configurationRoot);
            services.AddInfrastructure(configurationRoot);
        });
}
