using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Departments.Commands.Update
{
    public class DepartmentUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
