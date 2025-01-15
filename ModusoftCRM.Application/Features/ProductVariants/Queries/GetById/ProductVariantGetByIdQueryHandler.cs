using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.ProductVariants.Queries.GetById
{
    public class ProductVariantGetByIdQueryHandler : IRequestHandler<ProductVariantGetByIdQuery, ProductVariantGetByIdDto>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProductVariantGetByIdQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<ProductVariantGetByIdDto> Handle(ProductVariantGetByIdQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var productVariant = await dbContext.ProductVariants
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (productVariant == null)
            {
                throw new KeyNotFoundException("Ürün varyantı bulunamadı.");
            }

            return _mapper.Map<ProductVariantGetByIdDto>(productVariant);
        }
    }
}
