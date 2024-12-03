using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Departments.Commands.Add
{
    public class DepartmentAddCommandHandler : IRequestHandler<DepartmentAddCommand, int>
    {
        private readonly ITenantService _tenantService;

        public DepartmentAddCommandHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<int> Handle(DepartmentAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var department = new Department
            {
                Id = 0, 
                CreatedByUserId = "1",
                Name = request.Name,
                Description = request.Description
            };

            await dbContext.Departments.AddAsync(department, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return department.Id;
        }
    }
}
