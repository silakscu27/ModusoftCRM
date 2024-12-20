using MediatR;

namespace ModusoftCRM.Application.Features.Products.Queries.GetAll
{
    public class ProductGetAllQuery : IRequest<List<ProductGetAllDto>>
    {
    }
}
