using System.Collections.Generic;
using Flatik.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flatik.Data.Repositories
{
    public class FlatRepository : IFlatRepository
    {
        private readonly FlatikContext _context;
        private readonly DbSet<FlatEntity> _dbSet;

        public FlatRepository(FlatikContext context)
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