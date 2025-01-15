using FluentValidation;

namespace ModusoftCRM.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandValidator : AbstractValidator<OrderAddCommand>
    {
        public OrderAddCommandValidator()
        {
            RuleFor(x => x.FranchiseId)
                .NotEmpty()
                .WithMessage("FranchiseId alanı boş geçilemez.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Sipariş adı boş geçilemez.")
                .MaximumLength(200)
                .WithMessage("Sipariş adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Geçersiz sipariş durumu.");

            RuleFor(x => x.Currency)
                .IsInEnum()
                .WithMessage("Geçersiz para birimi.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0)
                .WithMessage("Toplam tutar sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TaxRate)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Vergi oranı negatif olamaz.");

            RuleFor(x => x.FinalAmount)
                .GreaterThanOrEqualTo(x => x.TotalAmount)
                .WithMessage("Son tutar, toplam tutardan küçük olamaz.");
        }
    }
}
