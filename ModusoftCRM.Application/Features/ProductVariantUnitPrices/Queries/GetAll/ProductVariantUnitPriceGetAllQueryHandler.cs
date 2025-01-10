using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetAll
{
    public class ProductVariantUnitPriceGetAllQueryHandler : IRequestHandler<ProductVariantUnitPriceGetAllQuery, List<ProductVariantUnitPriceGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProductVariantUnitPriceGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<ProductVariantUnitPriceGetAllDto>> Handle(ProductVariantUnitPriceGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            return await dbContext
                .ProductVariantUnitPrices
                .AsNoTracking()
                .Select(x => _mapper.Map<ProductVariantUnitPriceGetAllDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}
