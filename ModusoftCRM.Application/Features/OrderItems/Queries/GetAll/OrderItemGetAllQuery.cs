using MediatR;
using ModusoftCRM.Application.Features.OrderItems.Queries.GetAll;

namespace ModusoftCRM.Application.Features.OrderItems.Queries
{
    public class OrderItemGetAllQuery : IRequest<List<OrderItemGetAllDto>>
    {
    }
}
