using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Application.Features.Products.Queries.GetById
{
    public class ProductGetByIdQueryValidator : AbstractValidator<ProductGetByIdQuery>
    {
        private readonly IApplicationDbContext _context;

        public ProductGetByIdQueryValidator(ITenantService tenantService)
        {
            _context = tenantService.GetDbInstance(CancellationToken.None).GetAwaiter().GetResult();

            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen bir ürün seçiniz.");

            RuleFor(x => x.Id).MustAsync(AnyProductAsync).WithMessage("Seçili ürün bulunamadı.");
        }

        private Task<bool> AnyProductAsync(int id, CancellationToken cancellationToken)
        {
            return _context.Products.AnyAsync(x => x.Id == id, cancellationToken);
        }
    }
}
