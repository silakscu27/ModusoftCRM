using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class FranchiseRepository : Repository<Franchise, ApplicationDbContext>, IFranchiseRepository
{
    public FranchiseRepository(ApplicationDbContext context) : base(context)
    {
    }
}
