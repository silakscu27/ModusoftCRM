using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class ProposalItemRepository : Repository<ProposalItem, ApplicationDbContext>, IProposalItemRepository
{
    public ProposalItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}