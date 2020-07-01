using Flatik.Bot;
using Flatik.Monitoring.Settings;
using Microsoft.Extensions.Configuration;

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
          
            var client = new Client(botSettings, monitoringSettings, connectionString);
        }
    }
}