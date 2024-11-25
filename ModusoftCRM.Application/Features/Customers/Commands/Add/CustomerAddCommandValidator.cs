using CRM.Application.Customers.Commands;
using FluentValidation;

namespace CRM.Application.Features.Customers.Commands.Add
{
    public class CustomerAddCommandValidator : AbstractValidator<CustomerAddCommand>
    {
        public CustomerAddCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı boş geçilemez.")
                .MaximumLength(100)
                .WithMessage("İsim alanı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Açıklama alanı 500 karakterden büyük olamaz.");
        }
    }
}
