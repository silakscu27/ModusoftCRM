using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class FranchiseTypeRepository : Repository<FranchiseType, ApplicationDbContext>, IFranchiseTypeRepository
{
    public FranchiseTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}