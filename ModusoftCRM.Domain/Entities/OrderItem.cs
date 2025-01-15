using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Domain.Entities
{
    public class OrderItem : EntityBase<int>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!; 
        public string ProductVariantId { get; set; } = null!;
        public ProductVariant ProductVariant { get; set; } = null!;
        public int Quantity { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalUnitPrice { get; set; }
    }
}
