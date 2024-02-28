using SharedKernel.Core;

namespace Modules.Identity.Features.Registration;
internal struct RegistrationErrors
{
    internal static Error InvalidUserTypeToRegistrationFlow = Error.Validation("Identity.Registration", 
        "Selected User type is not valid to use this registration flow");
}
