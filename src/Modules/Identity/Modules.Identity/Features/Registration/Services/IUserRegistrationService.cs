using Microsoft.AspNetCore.Identity;
using Modules.Identity.Entities;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration.Services;
internal interface IUserRegistrationService
{
    Task<Result<bool>> RegisterUser(UserRegistrationCommand command);
    Task<ApplicationUser?> GetUserDetailsByEmail(string email);
}
