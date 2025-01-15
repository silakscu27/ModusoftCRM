using MediatR;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Application.Features.OrderItems.Commands.Update
{
    public class OrderItemUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public string ProductVariantId { get; set; } = null!;
        public DiscountType DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalUnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
