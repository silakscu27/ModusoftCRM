using AutoMapper;
using MediatR;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Common;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Add
{
    public class ProductVariantAddCommandHandler : IRequestHandler<ProductVariantAddCommand, Response<int>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public ProductVariantAddCommandHandler(
            IApplicationDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<int>> Handle(ProductVariantAddCommand request, CancellationToken cancellationToken)
        {
            var productVariant = _mapper.Map<ProductVariant>(request);

            productVariant.CreatedByUserId = _currentUserService.UserId
                ?? throw new ArgumentNullException(nameof(_currentUserService.UserId));
            productVariant.CreatedOn = DateTimeOffset.UtcNow;

            await _dbContext.ProductVariants.AddAsync(productVariant, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>(productVariant.Id, "Ürün varyantı başarıyla eklenmiştir.");
        }
    }
}
