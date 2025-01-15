using FluentValidation;

namespace ModusoftCRM.Application.Features.OrderItems.Commands.Update
{
    public class OrderItemUpdateCommandValidator : AbstractValidator<OrderItemUpdateCommand>
    {
        public OrderItemUpdateCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sipariş öğesi kimliği boş olamaz.");

            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Sipariş kimliği boş olamaz.");

            RuleFor(x => x.ProductVariantId)
                .NotEmpty()
                .WithMessage("Ürün varyantı kimliği boş olamaz.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Adet sıfırdan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Birim fiyatı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.FinalUnitPrice)
                .GreaterThanOrEqualTo(x => x.UnitPrice)
                .WithMessage("Nihai birim fiyatı, birim fiyatından küçük olamaz.");

            RuleFor(x => x.DiscountAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("İndirim tutarı sıfırdan küçük olamaz.");
        }
    }
}
