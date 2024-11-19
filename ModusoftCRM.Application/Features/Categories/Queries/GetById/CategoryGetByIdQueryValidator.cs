using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Categories.Queries.GetById
{
    public class CategoryGetByIdQueryValidator : AbstractValidator<CategoryGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public CategoryGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen bir kategori seçiniz.");

            RuleFor(x => x.Id).MustAsync(AnyCategoryAsync).WithMessage("Seçili kategori bulunamadı.");

        }

        private Task<bool> AnyCategoryAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Categories.AnyAsync(x => x.Id == id, cancellationToken);
        }

    }
}