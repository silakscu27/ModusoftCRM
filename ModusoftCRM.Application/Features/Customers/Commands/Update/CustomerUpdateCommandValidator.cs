using FluentValidation;

namespace CRM.Application.Customers.Commands
{
    public class CustomerUpdateCommandValidator : AbstractValidator<CustomerUpdateCommand>
    {
        public CustomerUpdateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad alanı boş geçilemez.");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Ad alanı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Müşteri kimliği boş olamaz.");
        }
    }
}
