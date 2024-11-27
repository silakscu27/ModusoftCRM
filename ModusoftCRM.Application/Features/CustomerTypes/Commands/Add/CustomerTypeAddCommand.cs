using MediatR;
using ModusoftCRM.Domain.Common;

namespace CRM.Application.Features.CustomerTypes.Commands.Add
{
    public class CustomerTypeAddCommand : IRequest<Response<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
