using FluentValidation;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Add
{
    public class ProductVariantAddCommandValidator : AbstractValidator<ProductVariantAddCommand>
    {
        public ProductVariantAddCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün ID boş geçilemez.")
                .MaximumLength(50).WithMessage("Ürün ID 50 karakterden uzun olamaz.");

            RuleFor(x => x.Thickness)
                .GreaterThan(0).WithMessage("Kalınlık 0'dan büyük olmalıdır.");

            RuleFor(x => x.Width)
                .GreaterThan(0).WithMessage("Genişlik 0'dan büyük olmalıdır.");

            RuleFor(x => x.Length)
                .GreaterThan(0).WithMessage("Uzunluk 0'dan büyük olmalıdır.");

            RuleFor(x => x.BasePrice)
                .GreaterThan(0).WithMessage("Taban fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.BrandName)
                .MaximumLength(200).WithMessage("Marka adı 200 karakterden uzun olamaz.");

            RuleFor(x => x.ColourName)
                .MaximumLength(200).WithMessage("Renk adı 200 karakterden uzun olamaz.");

            RuleFor(x => x.StockCode)
                .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.StockCode))
                .WithMessage("Stok kodu 100 karakterden uzun olamaz.");
        }
    }
}
