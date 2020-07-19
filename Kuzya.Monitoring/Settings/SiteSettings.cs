using System.Collections.Generic;

namespace Kuzya.Monitoring.Settings
{
    public class SiteSettings
    {
        /// <summary>
        /// Defines site name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Defines site url that will be used in the request.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Collection of parameters for passing into the request.
        /// </summary>
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();

        /// <summary>
        /// Defines type that will deserialize response json.
        /// </summary>
        public string DeserializerType { get; set; }

        /// <summary>
        /// Defines type that will deserialize response json.
        /// </summary>
        public int IntervalInSeconds { get; set; }
    }
}
