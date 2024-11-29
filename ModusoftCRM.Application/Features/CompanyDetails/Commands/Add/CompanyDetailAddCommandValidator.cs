using FluentValidation;

namespace CRM.Application.Features.CompanyDetails.Commands.Add
{
    public class CompanyDetailAddCommandValidator : AbstractValidator<CompanyDetailAddCommand>
    {
        public CompanyDetailAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Şirket adı boş geçilemez.")
                .MaximumLength(100).WithMessage("Şirket adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^[+]?[\s./0-9]*[(]?[0-9]{1,4}[)]?[-\s./0-9]*$")
                .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Geçerli bir telefon numarası giriniz.");
        }
    }
}