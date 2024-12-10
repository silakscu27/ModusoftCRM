using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class CountryRepository : Repository<Country, ApplicationDbContext>, ICountryRepository
{
    public CountryRepository(ApplicationDbContext context) : base(context)
    {
    }
}