namespace Modules.Identity.Features.Registration;
public sealed record UserRegistrationCommand (
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string ConfirmPassword
    );
