using ModusoftCRM.Domain.Enums;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetById
{
    public class ProductVariantUnitPriceGetByIdDto
    {
        public int Id { get; set; }
        public string ProductVariantId { get; set; } = string.Empty;
        public Guid FranchiseTypeId { get; set; }
        public string FranchiseTypeName { get; set; } = string.Empty;
        public DiscountType DiscountType { get; set; }
        public double DiscountAmount { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
