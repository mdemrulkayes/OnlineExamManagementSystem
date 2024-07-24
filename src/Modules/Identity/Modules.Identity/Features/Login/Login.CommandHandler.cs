using Modules.Identity.Features.Login.Services;
using Shared.Core;

namespace Modules.Identity.Features.Login;
internal class LoginCommandHandler(ILoginService loginService) : ICommandHandler<LoginCommand, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        return await loginService.Login(command);
    }
}
