using FluentValidation;

namespace ModusoftCRM.Application.Features.Products.Commands.Update
{
    public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ürün adı boş geçilemez.");

            RuleFor(x => x.Name)
                .MaximumLength(200)
                .WithMessage("Ürün adı 200 karakterden fazla olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(2000)
                .WithMessage("Açıklama 2000 karakterden fazla olamaz.");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Kategori seçimi yapılmalıdır.");
        }
    }
}
