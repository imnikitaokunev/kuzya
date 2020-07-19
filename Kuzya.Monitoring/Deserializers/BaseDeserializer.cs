using System.Collections.Generic;
using Kuzya.Monitoring.Models;

namespace Kuzya.Monitoring.Deserializers
{
    public abstract class BaseDeserializer : IDeserializer
    {
        protected readonly string SiteName;

        protected BaseDeserializer(string siteName) => SiteName = siteName;

        public abstract IEnumerable<Flat> Deserialize(string text);
    }
}
