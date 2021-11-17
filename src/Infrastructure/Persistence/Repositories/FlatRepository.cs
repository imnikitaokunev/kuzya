using Application.Common.Interfaces;
using Domain;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class FlatRepository : IFlatRepository
    {
        private readonly KuzyaContext _context;
        private readonly DbSet<FlatEntity> _dbSet;

        public FlatRepository(KuzyaContext context)
        {
            _context = context;
            _dbSet = _context.Set<FlatEntity>();
        }

        public void Add(FlatEntity flat)
        {
            _dbSet.Add(flat);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<FlatEntity> flats)
        {
            _dbSet.AddRange(flats);
            _context.SaveChanges();
        }

        public bool IsExists(long id, string site) => _dbSet.Find(id, site) != null;
    }
}
