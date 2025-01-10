using FluentValidation;
using ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Add;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Add
{
    public class ProductVariantUnitPriceAddCommandValidator : AbstractValidator<ProductVariantUnitPriceAddCommand>
    {
        public ProductVariantUnitPriceAddCommandValidator()
        {
            RuleFor(x => x.ProductVariantId)
                .NotEmpty()
                .WithMessage("Ürün çeşit ID'si boş geçilemez.");

            RuleFor(x => x.FranchiseTypeId)
                .NotEmpty()
                .WithMessage("Franchise tipi seçilmelidir.");

            RuleFor(x => x.FranchiseTypeName)
                .NotEmpty()
                .WithMessage("Franchise tipi adı boş geçilemez.")
                .MaximumLength(100)
                .WithMessage("Franchise tipi adı 100 karakterden fazla olamaz.");

            RuleFor(x => x.DiscountType)
                .IsInEnum()
                .WithMessage("Geçersiz indirim türü.");

            RuleFor(x => x.DiscountAmount)
                .GreaterThan(0)
                .WithMessage("İndirim miktarı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Birim fiyat sıfırdan büyük olmalıdır.");
        }
    }
}
