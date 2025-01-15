using MediatR;

namespace ModusoftCRM.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQuery : IRequest<OrderGetByIdDto>
    {
        public Guid OrderId { get; set; }

        public OrderGetByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
