using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.OrderItems.Queries.GetById
{
    public class OrderItemGetByIdQueryValidator : AbstractValidator<OrderItemGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public OrderItemGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.OrderItemId)
                .NotEmpty()
                .WithMessage("Lütfen bir sipariş öğesi ID'si giriniz.");

            RuleFor(x => x.OrderItemId)
                .MustAsync(AnyOrderItemAsync)
                .WithMessage("Seçili sipariş öğesi bulunamadı.");
        }

        private Task<bool> AnyOrderItemAsync(int orderItemId, CancellationToken cancellationToken)
        {
            return _context.OrderItems.AnyAsync(x => x.Id == orderItemId, cancellationToken);
        }
    }
}
