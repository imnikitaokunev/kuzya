using Application.Bot;
using Application.Common.Interfaces;
using Application.Models;
using Application.Models.Settings;
using Monitor = Infrastructure.Monitoring.Monitor;

namespace Kuzya
{
    public class Client
    {
        private readonly IBot _bot;
        private readonly Monitor _monitor;

        public Client(BotSettings botSettings, MonitoringSettings monitoringSettings, string connectionString)
        {
            _monitor = new Monitor(monitoringSettings, connectionString);
            _bot = new KuzyaBot(botSettings);

            _monitor.NewFlats += OnNewFlats;
        }

        public void Run()
        {
            _monitor.Run();
        }

        private void OnNewFlats(List<Flat> flats)
        {
            foreach (var flat in flats)
            {
                var owner = flat.IsOwner ? "" : "(а)";
                var flatDescription = $"{flat.Site}{owner} - {flat.UsdPrice}$ - {flat.BynPrice}р\n" + $"{flat.Link}";
                _bot.SendMessage(flatDescription);
                Console.WriteLine($"{flat.Site}{owner} - {flat.UsdPrice}$ - {flat.BynPrice}р");
            }
        }
    }
}