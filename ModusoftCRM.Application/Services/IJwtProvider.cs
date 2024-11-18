using ModusoftCRM.Application.Features.Auth.Login;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
