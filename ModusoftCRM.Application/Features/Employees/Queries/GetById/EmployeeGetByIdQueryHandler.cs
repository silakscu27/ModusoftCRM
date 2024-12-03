using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Employees.Queries.GetById
{
    public class EmployeeGetByIdQueryHandler : IRequestHandler<EmployeeGetByIdQuery, EmployeeGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public EmployeeGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<EmployeeGetByIdDto> Handle(EmployeeGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var employee = await dbContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new KeyNotFoundException("Çalışan bulunamadı.");
            }

            return _mapper.Map<EmployeeGetByIdDto>(employee);
        }
    }
}
