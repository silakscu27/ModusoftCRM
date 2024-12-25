using FluentValidation;

namespace ModusoftCRM.Application.Features.Franchises.Commands.Update
{
    public class FranchiseUpdateCommandValidator : AbstractValidator<FranchiseUpdateCommand>
    {
        public FranchiseUpdateCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Franchise ID boş olamaz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Franchise adı boş olamaz.")
                .MaximumLength(200).WithMessage("Franchise adı 200 karakterden uzun olamaz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş geçilemez.")
                .MaximumLength(5000).WithMessage("Açıklama 5000 karakterden uzun olamaz.");

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Geçerli bir telefon numarası giriniz.");

            RuleFor(x => x.FaxNumber)
                .Matches(@"^\+?\d{10,15}$")
                .WithMessage("Geçerli bir faks numarası giriniz.")
                .When(x => x.FaxNumber != null);

            RuleFor(x => x.TaxId)
                .MaximumLength(50).WithMessage("Vergi Kimlik Numarası 50 karakterden uzun olamaz.")
                .When(x => x.TaxId != null);

            RuleFor(x => x.TaxAdministration)
                .MaximumLength(100).WithMessage("Vergi Dairesi adı 100 karakterden uzun olamaz.")
                .When(x => x.TaxAdministration != null);

            RuleFor(x => x.LegalTaxName)
                .MaximumLength(200).WithMessage("Hukuki Vergi Adı 200 karakterden uzun olamaz.")
                .When(x => x.LegalTaxName != null);

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Geografik enlem -90 ile 90 arasında olmalıdır.")
                .When(x => x.Latitude.HasValue);

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Geografik boylam -180 ile 180 arasında olmalıdır.")
                .When(x => x.Longitude.HasValue);

            RuleFor(x => x.FranchiseTypeId)
                .NotEmpty().WithMessage("Franchise tipi boş geçilemez.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Müşteri ID boş geçilemez.");
        }
    }
}
