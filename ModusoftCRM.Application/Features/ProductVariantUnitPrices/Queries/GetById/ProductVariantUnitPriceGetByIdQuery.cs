using MediatR;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetById
{
    public class ProductVariantUnitPriceGetByIdQuery : IRequest<ProductVariantUnitPriceGetByIdDto>
    {
        public int Id { get; set; }

        public ProductVariantUnitPriceGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
