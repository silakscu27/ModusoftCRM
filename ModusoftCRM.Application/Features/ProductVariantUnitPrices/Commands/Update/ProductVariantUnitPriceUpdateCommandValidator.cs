using FluentValidation;

namespace ModusoftCRM.Application.Features.ProductVariantUnitPrices.Commands.Update
{
    public class ProductVariantUnitPriceUpdateCommandValidator : AbstractValidator<ProductVariantUnitPriceUpdateCommand>
    {
        public ProductVariantUnitPriceUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Geçerli bir ID girilmelidir.");

            RuleFor(x => x.ProductVariantId)
                .NotEmpty()
                .WithMessage("Ürün çeşidi ID'si boş geçilemez.");

            RuleFor(x => x.FranchiseTypeId)
                .NotEmpty()
                .WithMessage("Franchise tipi ID'si boş geçilemez.");

            RuleFor(x => x.FranchiseTypeName)
                .NotEmpty()
                .WithMessage("Franchise tipi adı boş geçilemez.")
                .MaximumLength(100)
                .WithMessage("Franchise tipi adı 100 karakterden fazla olamaz.");

            RuleFor(x => x.DiscountType)
                .IsInEnum()
                .WithMessage("Geçersiz indirim türü.");

            RuleFor(x => x.DiscountAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("İndirim miktarı sıfırdan küçük olamaz.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Birim fiyat sıfırdan büyük olmalıdır.");
        }
    }
}
