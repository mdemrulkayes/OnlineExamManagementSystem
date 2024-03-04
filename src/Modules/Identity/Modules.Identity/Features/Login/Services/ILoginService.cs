using SharedKernel.Core;

namespace Modules.Identity.Features.Login.Services;
internal interface ILoginService
{
    Task<Result<LoginResponse>> Login(LoginCommand command);
}
