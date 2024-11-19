using Finbuckle.MultiTenant;

namespace ModusoftCRM.Application.Common.Models
{
    public class ModuSoftTenantInfo : TenantInfo
    {
        public string UserId { get; set; } = string.Empty; // non-nullable error!!!
        public string ServerId { get; set; } = string.Empty;
    }
}