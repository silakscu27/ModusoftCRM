using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Application.Features.OrderItems.Queries.GetAll
{
    public class OrderItemGetAllDto
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public string ProductVariantId { get; set; } = string.Empty;
        public string ProductVariantName { get; set; } = string.Empty; 
        public int Quantity { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalUnitPrice { get; set; }
    }
}
