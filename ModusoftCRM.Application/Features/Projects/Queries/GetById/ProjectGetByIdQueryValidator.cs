using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Projects.Queries.GetById
{
    public class ProjectGetByIdQueryValidator : AbstractValidator<ProjectGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public ProjectGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen bir proje ID'si giriniz.");

            RuleFor(x => x.Id)
                .MustAsync(AnyProjectAsync)
                .WithMessage("Seçili proje bulunamadı.");
        }

        private Task<bool> AnyProjectAsync(string id, CancellationToken cancellationToken)
        {
            return _context.Projects.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
