namespace Modules.Identity.Features.Login;

internal sealed record LoginResponse(string UserId, string Email, string Name, string Token);
