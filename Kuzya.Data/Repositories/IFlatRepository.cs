using System.Collections.Generic;
using Kuzya.Data.Entities;

namespace Kuzya.Data.Repositories
{
    public interface IFlatRepository
    {
        void Add(FlatEntity flat);
        void AddRange(IEnumerable<FlatEntity> flats);
        bool IsExists(long id, string site);
    }
}
