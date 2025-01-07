using FluentValidation;

namespace ModusoftCRM.Application.Features.Cities.Commands.Add
{
    public class CityAddCommandValidator : AbstractValidator<CityAddCommand>
    {
        public CityAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Şehir adı boş geçilemez.")
                .MaximumLength(100).WithMessage("Şehir adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90)
                .When(x => x.Latitude.HasValue)
                .WithMessage("Enlem değeri -90 ile 90 arasında olmalıdır.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180)
                .When(x => x.Longitude.HasValue)
                .WithMessage("Boylam değeri -180 ile 180 arasında olmalıdır.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Geçerli bir ülke ID'si giriniz.");
        }
    }
}
