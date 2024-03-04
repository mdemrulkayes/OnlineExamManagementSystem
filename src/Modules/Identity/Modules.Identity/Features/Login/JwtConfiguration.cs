namespace Modules.Identity.Features.Login;
internal sealed record JwtConfiguration(
    string JwtKey, 
    string JwtExpireDay,
    string JwtIssuer,
    string JwtAudience
    );