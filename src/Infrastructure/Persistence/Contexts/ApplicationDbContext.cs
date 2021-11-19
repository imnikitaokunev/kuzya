using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Contexts
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<OnlinerApartment> OnlinerApartments { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<OnlinerSetup> OnlinerSetups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
