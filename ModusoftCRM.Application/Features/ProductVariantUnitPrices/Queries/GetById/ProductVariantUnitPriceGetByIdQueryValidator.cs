using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Queries.GetById
{
    public class ProductVariantUnitPriceGetByIdQueryValidator : AbstractValidator<ProductVariantUnitPriceGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public ProductVariantUnitPriceGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir ürün çeşidi birim fiyatı seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyProductVariantUnitPriceAsync)
                .WithMessage("Seçili ürün çeşidi birim fiyatı bulunamadı.");
        }

        private Task<bool> AnyProductVariantUnitPriceAsync(int id, CancellationToken cancellationToken)
        {
            return _context.ProductVariantUnitPrices.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
