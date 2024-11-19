namespace ModusoftCRM.Application.Common.Interfaces
{
    public interface ITenantService
    {
        Task<IApplicationDbContext> GetDbInstance(CancellationToken cancellationToken);
        Task<IApplicationDbContext> GetDbInstance(string tenantIdentifier, CancellationToken cancellationToken);
        Task CreateOrUpdateTenantDbAsync(string tenantIdentifier, CancellationToken cancellationToken);
    }
}