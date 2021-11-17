using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class OnlinerApartmentRepository : Repository<OnlinerApartment, long>, IOnlinerApartmentRepository
    {
        public OnlinerApartmentRepository(IApplicationDbContext context) : base(context)
        {
        }

        protected override DbSet<OnlinerApartment> DbSet => Context.OnlinerApartments;
    }
}
