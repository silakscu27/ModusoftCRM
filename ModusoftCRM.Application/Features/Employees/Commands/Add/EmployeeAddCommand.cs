using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Employees.Commands.Add
{
    public class EmployeeAddCommand : IRequest<Response<Guid>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MobilePhoneNumber { get; set; } = string.Empty;
        public string? WorkPhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
    }
}
