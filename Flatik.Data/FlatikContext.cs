using Flatik.Data.Configurations;
using Flatik.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flatik.Data
{
    public sealed class FlatikContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<FlatEntity> Flats { get; set; }

        public FlatikContext(string connectionString)
        {
            _connectionString = connectionString;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FlatConfiguration());
        }
    }
}
