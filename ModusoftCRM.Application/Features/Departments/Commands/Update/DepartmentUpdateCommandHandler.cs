using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Departments.Commands.Update
{
    public class DepartmentUpdateCommandHandler : IRequestHandler<DepartmentUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public DepartmentUpdateCommandHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var department = await dbContext.Departments
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (department == null)
            {
                return new Response<int>("Departman bulunamadı.", false);
            }

            department.Name = request.Name;
            department.Description = request.Description;

            dbContext.Departments.Update(department);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(department.Id, "Departman başarıyla güncellendi.");
        }
    }
}
