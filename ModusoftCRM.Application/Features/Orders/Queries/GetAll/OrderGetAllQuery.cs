using MediatR;
using ModusoftCRM.Application.Features.Orders.Queries.GetAll;

namespace ModusoftCRM.Application.Features.Orders.Queries
{
    public class OrderGetAllQuery : IRequest<List<OrderGetAllDto>>
    {
    }
}
