using FluentValidation;

namespace ModusoftCRM.Application.Features.Categories.Commands.Add
{
    public class CategoryAddCommandValidator : AbstractValidator<CategoryAddCommand>
    {
        public CategoryAddCommandValidator()
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