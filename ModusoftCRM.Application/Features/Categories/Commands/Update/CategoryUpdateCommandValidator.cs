
using FluentValidation;
using ModusoftCRM.Application.Features.Categories.Commands.Add;

namespace ModusoftCRM.Application.Features.Categories.Commands.Update
{
    public class CategoryUpdateCommandValidator : AbstractValidator<CategoryUpdateCommand>
    {
        public CategoryUpdateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad alanı boş geçilemez.");

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage("Ad alanı 50 karakterden büyük olamaz.");
        }
    }
}
