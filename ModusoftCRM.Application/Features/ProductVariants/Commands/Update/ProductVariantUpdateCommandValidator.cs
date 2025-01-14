using FluentValidation;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Update
{
    public class ProductVariantUpdateCommandValidator : AbstractValidator<ProductVariantUpdateCommand>
    {
        public ProductVariantUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Ürün varyant ID'si boş olamaz.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(100).WithMessage("İsim 100 karakterden uzun olamaz.");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).When(x => x.Price.HasValue)
                .WithMessage("Fiyat negatif olamaz.");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).When(x => x.Stock.HasValue)
                .WithMessage("Stok negatif olamaz.");
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün ID'si boş olamaz.");
        }
    }
}
