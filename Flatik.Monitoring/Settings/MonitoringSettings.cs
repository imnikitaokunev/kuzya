using System.Collections.Generic;

namespace Flatik.Monitoring.Settings
{
    public class MonitoringSettings
    {
        /// <summary>
        /// Defines collection of sites that will be monitored.
        /// </summary>
        public List<SiteSettings> Sites { get; set; }
    }
}
