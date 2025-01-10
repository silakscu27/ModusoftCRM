using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Domain.Entities
{
    public class ProductVariantUnitPrice : EntityBase<int>
    {
        public string ProductVariantId { get; set; } = string.Empty;
        public Guid FranchiseTypeId { get; set; }
        public string FranchiseTypeName { get; set; } = string.Empty;
        public DiscountType DiscountType { get; set; }
        public double DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
