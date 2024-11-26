using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Customers.Queries.GetById
{
    public class CustomerGetByIdQueryValidator : AbstractValidator<CustomerGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public CustomerGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir müşteri seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyCustomerAsync)
                .WithMessage("Seçili müşteri bulunamadı.");
        }

        private Task<bool> AnyCustomerAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Customers.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
