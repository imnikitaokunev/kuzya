using System.Collections.Generic;
using Flatik.Monitoring.Models;

namespace Flatik.Monitoring.Deserializers
{
    public abstract class BaseDeserializer : IDeserializer
    {
        protected readonly string SiteName;

        protected BaseDeserializer(string siteName) => SiteName = siteName;

        public abstract IEnumerable<Flat> Deserialize(string text);
    }
}
