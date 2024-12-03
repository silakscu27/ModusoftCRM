using MediatR;

namespace ModusoftCRM.Application.Features.Departments.Queries.GetAll
{
    public class DepartmentGetAllQuery : IRequest<List<DepartmentGetAllDto>>
    {
    }
}
