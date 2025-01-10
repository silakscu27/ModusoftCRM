using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Update
{
    public class ProductVariantUnitPriceUpdateCommandHandler : IRequestHandler<ProductVariantUnitPriceUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProductVariantUnitPriceUpdateCommandHandler(ITenantService tenantService, IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(ProductVariantUnitPriceUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var productVariantUnitPrice = await dbContext.ProductVariantUnitPrices.FindAsync(new object[] { request.Id }, cancellationToken);

            if (productVariantUnitPrice == null)
            {
                return new Response<int>(0, "Ürün varyantı birim fiyatı bulunamadı.");
            }

            productVariantUnitPrice.ProductVariantId = request.ProductVariantId;
            productVariantUnitPrice.FranchiseTypeId = request.FranchiseTypeId;
            productVariantUnitPrice.FranchiseTypeName = request.FranchiseTypeName;
            productVariantUnitPrice.DiscountType = request.DiscountType;
            productVariantUnitPrice.DiscountAmount = request.DiscountAmount;
            productVariantUnitPrice.UnitPrice = request.UnitPrice;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(productVariantUnitPrice.Id, "Ürün varyantı birim fiyatı başarıyla güncellendi.");
        }
    }
}
