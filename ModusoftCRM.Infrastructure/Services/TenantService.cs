using ModusoftCRM.Application.Common.Interfaces;

namespace ModusoftCRM.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        Task ITenantService.CreateOrUpdateTenantDbAsync(string tenantIdentifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IApplicationDbContext> ITenantService.GetDbInstance(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<IApplicationDbContext> ITenantService.GetDbInstance(string tenantIdentifier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
