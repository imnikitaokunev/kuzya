using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class OnlinerApartmentRepository : Repository<OnlinerApartment, long>, IOnlinerApartmentRepository
{
    protected override DbSet<OnlinerApartment> DbSet => Context.OnlinerApartments;

    public OnlinerApartmentRepository(IApplicationDbContext context) : base(context)
    {
    }
}
