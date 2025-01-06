using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Franchises.Queries.GetById
{
    public class FranchiseGetByIdQueryValidator : AbstractValidator<FranchiseGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public FranchiseGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir franchise seçiniz.");
             
            RuleFor(x => x.Id)
                .MustAsync(AnyFranchiseAsync)
                .WithMessage("Seçili franchise bulunamadı.");
        }

        private Task<bool> AnyFranchiseAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Franchises.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
