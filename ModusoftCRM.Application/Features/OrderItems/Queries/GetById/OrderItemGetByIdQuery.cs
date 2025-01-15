using MediatR;

namespace ModusoftCRM.Application.Features.OrderItems.Queries.GetById
{
    public class OrderItemGetByIdQuery : IRequest<OrderItemGetByIdDto>
    {
        public int OrderItemId { get; set; }

        public OrderItemGetByIdQuery(int orderItemId)
        {
            OrderItemId = orderItemId;
        }
    }
}
