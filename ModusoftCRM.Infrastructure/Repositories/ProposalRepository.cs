using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class ProposalRepository : Repository<Proposal, ApplicationDbContext>, IProposalRepository
{
    public ProposalRepository(ApplicationDbContext context) : base(context)
    {
    }
}