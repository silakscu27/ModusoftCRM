using MediatR;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Update
{
    public class ProductVariantUpdateCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
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
