using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Countries.Queries.GetById
{
    public class CountryGetByIdQueryValidator : AbstractValidator<CountryGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public CountryGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Lütfen bir ülke seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyCountryAsync).WithMessage("Seçili ülke bulunamadı.");
        }

        private Task<bool> AnyCountryAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Countries.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
