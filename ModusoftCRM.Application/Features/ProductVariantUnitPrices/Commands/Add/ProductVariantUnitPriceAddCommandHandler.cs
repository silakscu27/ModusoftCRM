using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Add
{
    public class ProductVariantUnitPriceAddCommandHandler : IRequestHandler<ProductVariantUnitPriceAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ProductVariantUnitPriceAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(ProductVariantUnitPriceAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var productVariantUnitPrice = _mapper.Map<ProductVariantUnitPrice>(request);

            productVariantUnitPrice.CreatedByUserId = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));

            await dbContext.ProductVariantUnitPrices.AddAsync(productVariantUnitPrice, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(productVariantUnitPrice.Id, "Fiyat başarıyla eklenmiştir.");
        }
    }
}
