using MediatR;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;
using System;

namespace ModusoftCRM.Application.Features.OrderItems.Commands.Add
{
    public class OrderItemAddCommand : IRequest<Response<int>>
    {
        public Guid OrderId { get; set; }
        public string ProductVariantId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalUnitPrice { get; set; }
    }
}
