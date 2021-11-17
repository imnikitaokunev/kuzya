using Application.Models;
using Application.Models.Settings;
using Application.Monitor;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Monitoring
{
    public class Monitor
    {
        private readonly MonitoringSettings _settings;
        private readonly string _connectionString;
        private readonly List<Site> _sites;

        public Monitor(MonitoringSettings settings, string connectionString)
        {
            _settings = settings;
            _connectionString = connectionString;

            _sites = _settings.Sites.Select(InitializeSite).ToList();
            _sites.ForEach(x => x.NewFlats += OnNewFlats);
        }

        public event Action<List<Flat>> NewFlats;

        public void Run()
        {
            var tasks = _sites.Select(s => new Task(s.Run));
            Parallel.ForEach(tasks, t => t.Start());
        }

        private Site InitializeSite(SiteSettings settings)
        {
            var context = new KuzyaContext(_connectionString);
            var repository = new FlatRepository(context);

            return new Site(settings, repository);
        }

        private void OnNewFlats(List<Flat> flats)
        {
            NewFlats?.Invoke(flats);
        }
    }
}
