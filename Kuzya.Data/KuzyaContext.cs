using Kuzya.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kuzya.Data
{
    public sealed class KuzyaContext : DbContext
    {
        private readonly string _connectionString;

        public KuzyaContext(string connectionString)
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
