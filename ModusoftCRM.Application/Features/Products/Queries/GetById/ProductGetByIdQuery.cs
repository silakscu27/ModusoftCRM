using MediatR;

namespace ModusoftCRM.Application.Features.Products.Queries.GetById
{
    public class ProductGetByIdQuery : IRequest<ProductGetByIdDto>
    {
        public int Id { get; set; }

        public ProductGetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
