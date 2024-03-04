using Modules.Identity.Features.Login.Services;
using SharedKernel.Core;

namespace Modules.Identity.Features.Login;
internal class LoginCommandHandler(ILoginService loginService) : ICommandHandler<LoginCommand, Result<LoginResponse>>
{
    public Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
