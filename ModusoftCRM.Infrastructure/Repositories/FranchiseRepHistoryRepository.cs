using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class FranchiseRepHistoryRepository : Repository<FranchiseRepresentativeHistory, ApplicationDbContext>, IFranchiseRepHistoryRepository
{
    public FranchiseRepHistoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
