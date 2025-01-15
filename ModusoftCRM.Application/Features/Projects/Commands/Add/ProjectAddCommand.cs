using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Projects.Commands.Add
{
    public class ProjectAddCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
