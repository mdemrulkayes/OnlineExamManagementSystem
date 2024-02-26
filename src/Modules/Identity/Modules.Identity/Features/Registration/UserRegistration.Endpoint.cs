using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Modules.Identity.Constants;
using Modules.Identity.Features.Registration.Services;

namespace Modules.Identity.Features.Registration;
internal static class UserRegistrationEndpoint
{
    internal static IEndpointRouteBuilder AddRegistrationEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost(IdentityRouteConstants.Register, (UserRegistrationCommand command, IUserRegistrationService userRegistrationService) =>
        {

        });

        return builder;
    }
}
