using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetById
{
    public class ProductVariantUnitPriceGetByIdQueryHandler : IRequestHandler<ProductVariantUnitPriceGetByIdQuery, ProductVariantUnitPriceGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProductVariantUnitPriceGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<ProductVariantUnitPriceGetByIdDto> Handle(ProductVariantUnitPriceGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var productVariantUnitPrice = await dbContext.ProductVariantUnitPrices
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (productVariantUnitPrice == null)
            {
                throw new KeyNotFoundException("Ürün çeşidi birim fiyatı bulunamadı.");
            }

            return _mapper.Map<ProductVariantUnitPriceGetByIdDto>(productVariantUnitPrice);
        }
    }
}
