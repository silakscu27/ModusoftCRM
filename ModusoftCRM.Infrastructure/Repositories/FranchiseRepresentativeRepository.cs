using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class FranchiseRepresentativeRepository : Repository<FranchiseRepresentative, ApplicationDbContext>, IFranchiseRepresentativeRepository
{
    public FranchiseRepresentativeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
