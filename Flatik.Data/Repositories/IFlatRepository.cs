using System.Collections.Generic;
using Flatik.Data.Entities;

namespace Flatik.Data.Repositories
{
    public interface IFlatRepository
    {
        void Add(FlatEntity flat);
        void AddRange(IEnumerable<FlatEntity> flats);
        bool IsExists(int id, string site);
    }
}
