using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Projects.Queries.GetById
{
    public class ProjectGetByIdQueryHandler : IRequestHandler<ProjectGetByIdQuery, ProjectGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProjectGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<ProjectGetByIdDto> Handle(ProjectGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var project = await dbContext.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (project == null)
            {
                throw new KeyNotFoundException("Proje bulunamadı.");
            }

            return _mapper.Map<ProjectGetByIdDto>(project);
        }
    }
}
