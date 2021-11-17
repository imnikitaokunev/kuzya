using Application.Common.Interfaces;
using Application.Models;

namespace Application.Deserializers
{
    public abstract class BaseDeserializer : IDeserializer
    {
        protected readonly string SiteName;

        protected BaseDeserializer(string siteName) => SiteName = siteName;

        public abstract IEnumerable<Flat> Deserialize(string text);
    }
}
