using Shared.Core;

namespace Modules.Identity.Features.Login;

internal sealed record LoginResponse(
    string UserId,
    string Email,
    string Name,
    string Token,
    string TokenType,
    long ExpiresIn = 3600)
{
    public Guid RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiryDate { get; private set; }

    public void SetRefreshToken(ITimeProvider timeProvider)
    {
        RefreshToken = Guid.NewGuid();
        RefreshTokenExpiryDate = timeProvider.TimeNow.AddDays(7).DateTime;
    }
}
