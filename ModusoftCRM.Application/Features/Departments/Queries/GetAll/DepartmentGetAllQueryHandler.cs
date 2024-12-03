using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.Departments.Queries.GetAll
{
    public class DepartmentGetAllQueryHandler : IRequestHandler<DepartmentGetAllQuery, List<DepartmentGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public DepartmentGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<DepartmentGetAllDto>> Handle(DepartmentGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var departments = await dbContext.Departments
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<DepartmentGetAllDto>>(departments);
        }
    }
}
