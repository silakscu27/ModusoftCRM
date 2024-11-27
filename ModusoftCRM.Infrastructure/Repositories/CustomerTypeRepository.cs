using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class CustomerTypeRepository : Repository<CustomerType, ApplicationDbContext>, ICustomerTypesRepository
{
    public CustomerTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}