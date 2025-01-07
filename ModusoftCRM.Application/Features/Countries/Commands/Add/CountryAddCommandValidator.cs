using FluentValidation;

namespace ModusoftCRM.Application.Features.Countries.Commands.Add
{
    public class CountryAddCommandValidator : AbstractValidator<CountryAddCommand>
    {
        public CountryAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad alanı boş geçilemez.")
                .MaximumLength(100)
                .WithMessage("Ad alanı 100 karakterden büyük olamaz.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("Enlem -90 ile 90 arasında olmalıdır.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("Boylam -180 ile 180 arasında olmalıdır.");
        }
    }
}
