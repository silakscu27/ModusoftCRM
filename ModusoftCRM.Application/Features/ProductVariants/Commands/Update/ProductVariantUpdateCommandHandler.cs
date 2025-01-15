using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Update
{
    public class ProductVariantUpdateCommandHandler : IRequestHandler<ProductVariantUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;

        public ProductVariantUpdateCommandHandler(
            ITenantService tenantService,
            IMapper mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(ProductVariantUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var productVariant = await dbContext.ProductVariants
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (productVariant == null)
                return new Response<int>(0, $"Ürün varyantı (ID: {request.Id}) bulunamadı.");

            _mapper.Map(request, productVariant);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(productVariant.Id, "Ürün varyantı Başarıyla Güncellenmiştir");
        }
    }
}
