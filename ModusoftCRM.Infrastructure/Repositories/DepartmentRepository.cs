using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class DepartmentRepository : Repository<Department, ApplicationDbContext>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}