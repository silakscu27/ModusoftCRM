using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Employees.Queries.GetAll
{
    public class EmployeeGetAllQueryHandler : IRequestHandler<EmployeeGetAllQuery, List<EmployeeGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public EmployeeGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<EmployeeGetAllDto>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Employees
                .AsNoTracking()
                .Select(x => _mapper.Map<EmployeeGetAllDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}
