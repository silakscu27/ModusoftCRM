using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Orders.Queries.GetById
{
    public class OrderGetByIdQueryValidator : AbstractValidator<OrderGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public OrderGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Lütfen bir sipariş ID'si giriniz.");

            RuleFor(x => x.OrderId)
                .MustAsync(AnyOrderAsync)
                .WithMessage("Seçili sipariş bulunamadı.");
        }

        private Task<bool> AnyOrderAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return _context.Orders.AnyAsync(x => x.Id == orderId, cancellationToken);
        }
    }
}
