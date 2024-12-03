using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Employees.Queries.GetById
{
    public class EmployeeGetByIdQueryValidator : AbstractValidator<EmployeeGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public EmployeeGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir çalışan seçiniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyEmployeeAsync)
                .WithMessage("Seçili çalışan bulunamadı.");
        }

        private Task<bool> AnyEmployeeAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Employees.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
