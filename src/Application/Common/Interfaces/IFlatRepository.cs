using Domain;

namespace Application.Common.Interfaces
{
    public interface IFlatRepository
    {
        void Add(FlatEntity flat);
        void AddRange(IEnumerable<FlatEntity> flats);
        bool IsExists(long id, string site);
    }
}
