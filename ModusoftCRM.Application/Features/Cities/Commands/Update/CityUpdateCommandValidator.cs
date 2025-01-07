using FluentValidation;

namespace ModusoftCRM.Application.Features.Cities.Commands.Update
{
    public class CityUpdateCommandValidator : AbstractValidator<CityUpdateCommand>
    {
        public CityUpdateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90)
                .WithMessage("Latitude must be between -90 and 90.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180)
                .WithMessage("Longitude must be between -180 and 180.");

            RuleFor(x => x.CountryId)
                .GreaterThan(0)
                .WithMessage("CountryId must be greater than 0.");
        }
    }
}
