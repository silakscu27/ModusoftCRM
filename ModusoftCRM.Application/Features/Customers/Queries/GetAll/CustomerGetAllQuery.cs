using MediatR;

namespace ModusoftCRM.Application.Features.Customers.Queries.GetAll
{
    public class CustomerGetAllQuery : IRequest<List<CustomerGetAllDto>>
    {
    }
}
