using MediatR;

namespace ModusoftCRM.Application.Features.Employees.Queries.GetAll
{
    public class EmployeeGetAllQuery : IRequest<List<EmployeeGetAllDto>>
    {
    }
}
