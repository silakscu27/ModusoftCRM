using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class ProductVariantUnitPriceRepository : Repository<ProductVariantUnitPrice, ApplicationDbContext>, IProductVariantUnitPriceRepository
{
    public ProductVariantUnitPriceRepository(ApplicationDbContext context) : base(context)
    {
    }
}