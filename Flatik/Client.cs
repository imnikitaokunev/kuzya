using System;
using System.Collections.Generic;
using Flatik.Bot;
using Flatik.Data;
using Flatik.Monitoring.Models;
using Flatik.Monitoring.Monitor;
using Flatik.Monitoring.Settings;

namespace Flatik
{
    public class Client
    {
        private readonly IBot _bot;
        private readonly Monitor _monitor;

        public Client(BotSettings botSettings, MonitoringSettings monitoringSettings, string connectionString)
        {
            var context = new FlatikContext(connectionString);

            _monitor = new Monitor(monitoringSettings, context);
            _bot = new FlatikBot(botSettings);

            _monitor.NewFlats += OnNewFlats;
            _monitor.Run();
        }

        private void OnNewFlats(List<Flat> flats)
        {
            foreach (var flat in flats)
            {
                var flatDescription = $"{flat.Site} - {flat.UsdPrice}$ - {flat.BynPrice}р\n" + $"{flat.Link}";
                _bot.SendMessage(flatDescription);
                Console.WriteLine($"{flat.Site} - {flat.UsdPrice}$ - {flat.BynPrice}р");
            }
        }
    }
}