using FluentValidation;

namespace CRM.Application.Features.CustomerTypes.Commands.Add
{
    public class CustomerTypeAddCommandValidator : AbstractValidator<CustomerTypeAddCommand>
    {
        public CustomerTypeAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Müşteri türü ismi boş geçilemez.")
                .MaximumLength(100)
                .WithMessage("Müşteri türü ismi en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama alanı 500 karakterden büyük olamaz.");
        }
    }
}
