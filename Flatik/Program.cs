using System;
using Flatik.Bot;
using Flatik.Monitoring.Settings;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;

namespace Flatik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();


            var botSettings = configuration.GetSection(nameof(BotSettings)).Get<BotSettings>();
            var monitoringSettings = configuration.GetSection(nameof(MonitoringSettings)).Get<MonitoringSettings>();
            var connectionString = configuration.GetConnectionString("Default");
            
            LogManager.Configuration = new NLogLoggingConfiguration(configuration.GetSection("NLog"));

            var client = new Client(botSettings, monitoringSettings, connectionString);
            client.Run();

            Console.ReadLine();
        }
    }
}