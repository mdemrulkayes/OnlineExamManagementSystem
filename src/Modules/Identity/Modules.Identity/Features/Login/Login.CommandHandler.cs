using Microsoft.Extensions.Logging;
using Modules.Identity.Features.Login.Services;
using Shared.Core;

namespace Modules.Identity.Features.Login;
internal class LoginCommandHandler(ILoginService loginService, ILogger<LoginCommandHandler> logger) : ICommandHandler<LoginCommand, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Inside login command handler");
        return await loginService.Login(command);
    }
}
