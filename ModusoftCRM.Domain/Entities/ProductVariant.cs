using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Domain.Entities
{
    public class ProductVariant : EntityBase<int>
    {
        public string ProductId { get; set; } = string.Empty; 
        public int Thickness { get; set; } 
        public double Width { get; set; } 
        public double Length { get; set; } 
        public decimal BasePrice { get; set; } 
        //public ProductUnit Unit { get; set; } = ProductUnit.None; 
        public string? StockCode { get; set; } 

        public int? BrandId { get; set; } 
        public string BrandName { get; set; } = string.Empty; 

        public int? ColourId { get; set; } 
        public string ColourName { get; set; } = string.Empty; 

        public ICollection<ProductVariantUnitPrice> UnitPrices { get; set; } = new List<ProductVariantUnitPrice>();
    }
}
