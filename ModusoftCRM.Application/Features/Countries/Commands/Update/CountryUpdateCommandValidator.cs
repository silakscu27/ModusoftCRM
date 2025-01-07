using FluentValidation;

namespace ModusoftCRM.Application.Features.Countries.Commands.Update
{
    public class CountryUpdateCommandValidator : AbstractValidator<CountryUpdateCommand>
    {
        public CountryUpdateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad alanı boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Ad alanı 100 karakteri geçemez.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("Enlem -90 ile 90 arasında olmalıdır.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("Boylam -180 ile 180 arasında olmalıdır.");
        }
    }
}
