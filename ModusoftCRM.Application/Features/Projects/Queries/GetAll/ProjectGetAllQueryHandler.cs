using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Projects.Queries.GetAll
{
    public class ProjectGetAllQueryHandler : IRequestHandler<ProjectGetAllQuery, List<ProjectGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProjectGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<ProjectGetAllDto>> Handle(ProjectGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .Projects
                .AsNoTracking() 
                .Select(x => _mapper.Map<ProjectGetAllDto>(x)) 
                .ToListAsync(cancellationToken); 
        }
    }
}
