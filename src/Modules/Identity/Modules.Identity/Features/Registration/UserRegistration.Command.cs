using Modules.Identity.Features.Registration.Enums;
using Shared.Core;

namespace Modules.Identity.Features.Registration;
internal sealed record UserRegistrationCommand (
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string ConfirmPassword,
    UserType UserType
    ) : ICommand<Result<bool>>;
