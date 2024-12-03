using MediatR;

namespace ModusoftCRM.Application.Features.Employees.Queries.GetById
{
    public class EmployeeGetByIdQuery : IRequest<EmployeeGetByIdDto>
    {
        public Guid Id { get; set; }

        public EmployeeGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
