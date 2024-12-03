using MediatR;

namespace ModusoftCRM.Application.Features.Departments.Commands.Add
{
    public class DepartmentAddCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
