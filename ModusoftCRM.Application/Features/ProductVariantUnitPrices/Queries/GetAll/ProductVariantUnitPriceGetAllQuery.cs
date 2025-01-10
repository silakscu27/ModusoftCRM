using MediatR;
using System.Collections.Generic;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetAll
{
    public class ProductVariantUnitPriceGetAllQuery : IRequest<List<ProductVariantUnitPriceGetAllDto>>
    {
    }
}
