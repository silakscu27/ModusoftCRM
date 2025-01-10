using FluentValidation;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Update
{
    public class FranchiseRepHistoryUpdateCommandValidator : AbstractValidator<FranchiseRepHistoryUpdateCommand>
    {
        public FranchiseRepHistoryUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen geçerli bir ID giriniz.");

            RuleFor(x => x.FranchiseRepresentativeId)
                .NotEmpty()
                .WithMessage("Franchise Temsilci ID boş olamaz.");

            RuleFor(x => x.FranchiseId)
                .NotEmpty()
                .WithMessage("Franchise ID boş olamaz.");

            RuleFor(x => x.From)
                .LessThanOrEqualTo(x => x.To)
                .WithMessage("Başlangıç tarihi Bitiş tarihinden büyük olamaz.");

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("Rol bilgisi boş olamaz.")
                .MaximumLength(100)
                .WithMessage("Rol bilgisi 100 karakterden fazla olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama 500 karakterden fazla olamaz.");
        }
    }
}
