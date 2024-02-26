using Microsoft.AspNetCore.Identity;
using Modules.Identity.Entities;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration.Services;
internal class UserRegistrationService(UserManager<ApplicationUser> userManager) : IUserRegistrationService
{
    public async Task<Result<IdentityResult>> RegisterUser(UserRegistrationCommand command)
    {
        var user = ApplicationUser.RegisterUser(command.FirstName, command.LastName, command.Email, command.PhoneNumber);
        return await userManager.CreateAsync(user, command.Password);
    }

    public async Task<ApplicationUser?> GetUserDetailsByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }
}
