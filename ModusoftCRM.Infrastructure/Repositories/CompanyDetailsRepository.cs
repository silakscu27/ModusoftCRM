using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class CompanyDetailsRepository : Repository<CompanyDetail, ApplicationDbContext>, ICompanyDetailRepository
{
    public CompanyDetailsRepository(ApplicationDbContext context) : base(context)
    {
    }
}