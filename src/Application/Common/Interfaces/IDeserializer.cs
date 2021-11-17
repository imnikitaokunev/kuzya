using Application.Models;

namespace Application.Common.Interfaces
{
    internal interface IDeserializer
    {
        IEnumerable<Flat> Deserialize(string text);
    }
}
