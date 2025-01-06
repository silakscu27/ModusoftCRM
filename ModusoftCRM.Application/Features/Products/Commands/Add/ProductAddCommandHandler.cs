using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.Products.Commands.Add
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, Response<int>>
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ProductAddCommandHandler(ITenantService tenantService, IMapper mapper, ICurrentUserService currentUserService)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var dbContext = await _tenantService.GetDbInstance(cancellationToken);

            var product = _mapper.Map<Product>(request);

            product.CreatedByUserId = _currentUserService.UserId ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));

            await dbContext.Products.AddAsync(product, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(product.Id, "Ürün başarıyla eklenmiştir.");
        }
    }
}
