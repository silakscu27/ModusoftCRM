using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.FranchiseRepHistories.Queries.GetById
{
    public class FranchiseRepHistoryGetByIdQueryValidator : AbstractValidator<FranchiseRepHistoryGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public FranchiseRepHistoryGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir Franchise temsilci geçmişi ID'si giriniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyFranchiseRepHistoryAsync)
                .WithMessage("Seçili Franchise temsilci geçmişi bulunamadı.");
        }

        private Task<bool> AnyFranchiseRepHistoryAsync(int id, CancellationToken cancellationToken)
        {
            return _context.FranchiseRepresentativeHistories.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
