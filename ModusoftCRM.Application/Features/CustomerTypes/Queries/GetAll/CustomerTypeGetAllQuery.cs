using MediatR;

namespace ModusoftCRM.Application.Features.CustomerTypes.Queries.GetAll
{
    public class CustomerTypeGetAllQuery : IRequest<List<CustomerTypeGetAllDto>>
    {
    }
}
