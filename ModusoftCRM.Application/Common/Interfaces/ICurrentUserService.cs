using ModusoftCRM.Application.Common.Models;

namespace ModusoftCRM.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; } 
        ModuSoftTenantInfo? ModuSoftTenantInfo { get; } 
    }
}
