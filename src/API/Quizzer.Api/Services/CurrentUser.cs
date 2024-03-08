using System.Security.Claims;
using SharedKernel.Core;

namespace Quizzer.Api.Services;

public sealed class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User.FindFirstValue("UserId");
}
