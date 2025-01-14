using MediatR;

namespace ModusoftCRM.Application.Features.ProductVariants.Queries.GetById
{
    public class ProductVariantGetByIdQuery : IRequest<ProductVariantGetByIdDto>
    {
        public int Id { get; set; }

        public ProductVariantGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
