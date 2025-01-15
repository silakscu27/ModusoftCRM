using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.ProductVariants.Queries.GetAll
{
    public class ProductVariantGetAllQuery : IRequest<List<ProductVariantGetAllDto>>
    {
    }
}
