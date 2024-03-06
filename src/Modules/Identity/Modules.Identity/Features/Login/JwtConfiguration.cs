namespace Modules.Identity.Features.Login;

internal sealed class JwtConfiguration
{

    public string JwtKey { get; init; }
    public string JwtExpireDay { get; init; }
    public string JwtIssuer { get; init; }
    public string JwtAudience { get; init; }
}