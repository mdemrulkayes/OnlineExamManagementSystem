using Shared.Core;

namespace Modules.Identity.Features.Login;

internal sealed record AccessTokenResponse(
    string Token,
    string TokenType,
    long ExpiresIn = 3600)
{
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiryDate { get; private set; }

    public void SetRefreshToken(string token, ITimeProvider timeProvider)
    {
        RefreshToken = token;
        RefreshTokenExpiryDate = timeProvider.TimeNow.AddDays(7).DateTime;
    }
}
