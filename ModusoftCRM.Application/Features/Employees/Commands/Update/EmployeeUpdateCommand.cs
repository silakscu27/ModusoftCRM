using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.Employees.Commands.Update
{
    public class EmployeeUpdateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhoneNumber { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? DepartmentId { get; set; }
    }
}
