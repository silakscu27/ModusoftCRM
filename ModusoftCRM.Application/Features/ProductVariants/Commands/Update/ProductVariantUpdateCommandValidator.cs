using FluentValidation;

namespace ModusoftCRM.Application.Features.ProductVariants.Commands.Update
{
    public class ProductVariantUpdateCommandValidator : AbstractValidator<ProductVariantUpdateCommand>
    {
        public ProductVariantUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Variant ID boş olamaz.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün ID boş olamaz.");
            RuleFor(x => x.Thickness).GreaterThan(0).WithMessage("Kalınlık pozitif bir değer olmalıdır.");
            RuleFor(x => x.Width).GreaterThan(0).WithMessage("Genişlik pozitif bir değer olmalıdır.");
            RuleFor(x => x.Length).GreaterThan(0).WithMessage("Uzunluk pozitif bir değer olmalıdır.");
            RuleFor(x => x.BasePrice).GreaterThan(0).WithMessage("Taban fiyatı pozitif bir değer olmalıdır.");
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka adı boş olamaz.");
            RuleFor(x => x.ColourName).NotEmpty().WithMessage("Renk adı boş olamaz.");
        }
    }
}
