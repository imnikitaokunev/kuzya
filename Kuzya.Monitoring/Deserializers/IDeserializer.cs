using System.Collections.Generic;
using Kuzya.Monitoring.Models;

namespace Kuzya.Monitoring.Deserializers
{
    internal interface IDeserializer
    {
        IEnumerable<Flat> Deserialize(string text);
    }
}
