using System;
using System.Collections.Generic;
using Flatik.Bot;
using Flatik.Data;
using Flatik.Data.Repositories;
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
            var repository = new FlatRepository(context);

            _monitor = new Monitor(monitoringSettings, repository);
            _bot = new FlatikBot(botSettings);

            _monitor.NewFlats += OnNewFlats;
            _monitor.Run();
        }

        public void Run()
        {
            _monitor.Run();
        }

        private void OnNewFlats(List<Flat> flats)
        {
            foreach (var flat in flats)
            {
                var owner = flat.IsOwner ? "(а)" : "";
                var flatDescription = $"{flat.Site}{owner} - {flat.UsdPrice}$ - {flat.BynPrice}р\n" + $"{flat.Link}";
                _bot.SendMessage(flatDescription);
                Console.WriteLine($"{flat.Site}{owner} - {flat.UsdPrice}$ - {flat.BynPrice}р");
            }
        }
    }
}