using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Projects.Commands.Update
{
    public class ProjectUpdateCommand : IRequest<Response<string>>
    {
        public string Id { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
