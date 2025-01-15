using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Projects.Commands.Update
{
    public class ProjectUpdateCommandHandler : IRequestHandler<ProjectUpdateCommand, Response<string>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProjectUpdateCommandHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(ProjectUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var project = await dbContext.Projects.FindAsync(new object[] { request.Id }, cancellationToken);

            if (project == null)
            {
                return new Response<string>("", "Proje bulunamadı.");
            }

            // Update
            project.Name = request.Name ?? project.Name;
            project.Description = request.Description ?? project.Description;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<string>(project.Id, "Proje başarıyla güncellendi.");
        }
    }
}
