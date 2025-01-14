using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Add
{
    public class ProductVariantAddCommand : IRequest<Response<int>>
    {
        public string ProductId { get; set; } = string.Empty;
        public int Thickness { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal BasePrice { get; set; }
        public string? StockCode { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public int? ColourId { get; set; }
        public string ColourName { get; set; } = string.Empty;
    }
}
