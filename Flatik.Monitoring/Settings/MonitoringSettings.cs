using System.Collections.Generic;

namespace Flatik.Monitoring.Settings
{
    public class MonitoringSettings
    {
        /// <summary>
        /// Defines the interval between flats monitoring requests.
        /// </summary>
        public int IntervalInSeconds { get; set; }
        
        /// <summary>
        /// Defines new flats created limit.
        /// </summary>
        public int NewFlatConditionInSeconds { get; set; }

        /// <summary>
        /// Defines collection of sites that will be monitored.
        /// </summary>
        public List<SiteSettings> Sites { get; set; }
    }
}
