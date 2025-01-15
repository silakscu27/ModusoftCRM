using ModusoftCRM.Domain.Entities;
using ModusoftCRM.Domain.Repositories;
using ModusoftCRM.Infrastructure.Context;
using GenericRepository;

namespace ModusoftCRM.Infrastructure.Repositories;
internal sealed class ProductVariantRepository : Repository<ProductVariant, ApplicationDbContext>, IProductVariantRepository
{
    public ProductVariantRepository(ApplicationDbContext context) : base(context)
    {
    }
}