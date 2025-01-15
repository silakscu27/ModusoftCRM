using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Projects.Commands.Add
{
    public class ProjectAddCommandHandler : IRequestHandler<ProjectAddCommand, Response<string>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ProjectAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(ProjectAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var project = _mapper.Map<Project>(request);

            project.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));

            await dbContext.Projects.AddAsync(project, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<string>(project.Id, "Proje başarıyla eklenmiştir.");
        }
    }
}
