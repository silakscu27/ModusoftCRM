using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class CityRepository : Repository<City, ApplicationDbContext>, ICityRepository
{
    public CityRepository(ApplicationDbContext context) : base(context)
    {
    }
}