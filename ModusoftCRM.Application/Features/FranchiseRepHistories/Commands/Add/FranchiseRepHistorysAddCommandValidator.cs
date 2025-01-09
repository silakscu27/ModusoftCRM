using FluentValidation;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Commands.Add
{
    public class FranchiseRepHistorysAddCommandValidator : AbstractValidator<FranchiseRepHistoryAddCommand>
    {
        public FranchiseRepHistorysAddCommandValidator()
        {
            RuleFor(x => x.FranchiseRepresentativeId)
                .NotEmpty().WithMessage("Franchise temsilci ID boş geçilemez.");

            RuleFor(x => x.FranchiseId)
                .NotEmpty().WithMessage("Franchise ID boş geçilemez.");

            RuleFor(x => x.From)
                .NotEmpty().WithMessage("Başlangıç tarihi boş geçilemez.")
                .LessThanOrEqualTo(x => x.To).WithMessage("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");

            RuleFor(x => x.To)
                .NotEmpty().WithMessage("Bitiş tarihi boş geçilemez.")
                .GreaterThanOrEqualTo(x => x.From).WithMessage("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Rol boş geçilemez.")
                .MaximumLength(100).WithMessage("Rol 100 karakterden uzun olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz.");
        }
    }
}
