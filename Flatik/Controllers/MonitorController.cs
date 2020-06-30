using Flatik.Monitoring.Monitor;
using Flatik.Monitoring.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Flatik.Controllers
{
    public class MonitorController
    {
        private readonly MonitoringSettings _settings;
        private readonly Monitor _monitor;

        public MonitorController(IOptionsMonitor<MonitoringSettings> optionsMonitor)
        {
            _settings = optionsMonitor.CurrentValue;
            _monitor = new Monitor(_settings);
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var list = _monitor.Run();
            return new ObjectResult(list);
        }
    }
}
