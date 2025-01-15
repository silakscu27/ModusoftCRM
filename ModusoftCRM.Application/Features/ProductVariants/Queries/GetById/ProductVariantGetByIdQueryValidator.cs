using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.ProductVariants.Queries.GetById
{
    public class ProductVariantGetByIdQueryValidator : AbstractValidator<ProductVariantGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public ProductVariantGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir ürün varyantı seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyProductVariantAsync)
                .WithMessage("Seçili ürün varyantı bulunamadı.");
        }

        private Task<bool> AnyProductVariantAsync(int id, CancellationToken cancellationToken)
        {
            return _context.ProductVariants.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
