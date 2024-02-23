using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IJwtAuthenticationTokenRepository
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}
