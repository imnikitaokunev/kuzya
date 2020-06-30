using System.Collections.Generic;
using Flatik.Monitoring.Models;

namespace Flatik.Monitoring.Deserializers
{
    internal interface IDeserializer
    {
        IEnumerable<SiteModel> Deserialize(string json);
    }
}
