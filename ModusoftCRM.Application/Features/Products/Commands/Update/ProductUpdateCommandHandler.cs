using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Products.Commands.Update
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ProductUpdateCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var product = await dbContext.Products.FindAsync(new object[] { request.Id }, cancellationToken);

            if (product == null)
            {
                return new Response<int>(0, "Ürün bulunamadı.");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(product.Id, "Ürün başarıyla güncellendi.");
        }
    }
}
