using System.Collections.Generic;
using Flatik.Monitoring.Models;

namespace Flatik.Monitoring.Deserializers
{
    internal interface IDeserializer
    {
        IEnumerable<Flat> Deserialize(string json);
    }
}
