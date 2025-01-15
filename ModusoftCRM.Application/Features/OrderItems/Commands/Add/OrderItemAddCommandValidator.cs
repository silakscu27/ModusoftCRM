using FluentValidation;
using ModusoftCRM.Application.Features.OrderItems.Commands.Add;

namespace ModusoftCRM.Application.Features.OrderItems.Commands
{
    public class OrderItemAddCommandValidator : AbstractValidator<OrderItemAddCommand>
    {
        public OrderItemAddCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Sipariş ID boş geçilemez.");

            RuleFor(x => x.ProductVariantId)
                .NotEmpty()
                .WithMessage("Ürün varyantı ID boş geçilemez.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Miktar sıfırdan büyük olmalıdır.");

            RuleFor(x => x.DiscountAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("İndirim tutarı sıfır veya daha büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Birim fiyat sıfırdan büyük olmalıdır.");

            RuleFor(x => x.FinalUnitPrice)
                .GreaterThanOrEqualTo(x => x.UnitPrice)
                .WithMessage("Nihai birim fiyat, birim fiyatından küçük olamaz.");
        }
    }
}
