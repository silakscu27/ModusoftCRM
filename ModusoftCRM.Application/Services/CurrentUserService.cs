using Microsoft.AspNetCore.Http;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Application.Common.Models;
using System.Security.Claims;

namespace ModusoftCRM.Application.Common.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId =>
            _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public ModuSoftTenantInfo? ModuSoftTenantInfo =>
            _httpContextAccessor.HttpContext?.Items["TenantInfo"] as ModuSoftTenantInfo;
    }
}
