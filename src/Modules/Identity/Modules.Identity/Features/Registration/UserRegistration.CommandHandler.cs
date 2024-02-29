using Modules.Identity.Features.Registration.Services;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration;
internal sealed class UserRegistrationCommandHandler(IUserRegistrationService userRegistrationService) : ICommandHandler<UserRegistrationCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UserRegistrationCommand command, CancellationToken cancellationToken)
    {
        var result = await userRegistrationService.RegisterUser(command);
        return result;
    }
}