using System.Collections.Generic;
using System.Linq;
using Kuzya.Monitoring.Settings;

namespace Kuzya.Monitoring.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Transforms a collection of <see cref="Parameter"/> to query string.
        /// </summary>
        /// <param name="parameters">Collection of parameters that will be transformed to query string.</param>
        /// <returns>Query string.</returns>
        public static string ToQueryString(this IEnumerable<Parameter> parameters)
        {
            var queryParameters = parameters.Select(x => x.Name + "=" + x.Value);
            return "?" + string.Join('&', queryParameters);
        }
    }
}
