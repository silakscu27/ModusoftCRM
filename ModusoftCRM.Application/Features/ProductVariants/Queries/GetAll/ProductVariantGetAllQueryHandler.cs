using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.ProductVariants.Queries.GetAll
{
    public class ProductVariantGetAllQueryHandler : IRequestHandler<ProductVariantGetAllQuery, List<ProductVariantGetAllDto>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProductVariantGetAllQueryHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<List<ProductVariantGetAllDto>> Handle(ProductVariantGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var productVariants = await dbContext.ProductVariants
                .AsNoTracking()
                .Include(x => x.UnitPrices) 
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<ProductVariantGetAllDto>>(productVariants);
        }
    }
}
