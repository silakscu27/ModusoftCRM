using FluentValidation;
using ModusoftCRM.Application.Features.Orders.Commands.Update;

namespace ModusoftCRM.Application.Features.Orders.Commands
{
    public class OrderUpdateCommandValidator : AbstractValidator<OrderUpdateCommand>
    {
        public OrderUpdateCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Sipariş adı boş geçilemez.");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Sipariş adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sipariş kimliği boş olamaz.");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Geçerli bir sipariş durumu seçilmelidir.");

            RuleFor(x => x.Currency)
                .IsInEnum()
                .WithMessage("Geçerli bir para birimi seçilmelidir.");

            RuleFor(x => x.TaxRate)
                .InclusiveBetween(0, 100)
                .WithMessage("Vergi oranı 0 ile 100 arasında olmalıdır.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0)
                .WithMessage("Toplam tutar sıfırdan büyük olmalıdır.");

            RuleFor(x => x.FinalAmount)
                .GreaterThanOrEqualTo(x => x.TotalAmount)
                .WithMessage("Nihai tutar, toplam tutardan küçük olamaz.");
        }
    }
}
