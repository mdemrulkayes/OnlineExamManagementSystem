using Microsoft.AspNetCore.Routing;
using Modules.Identity.Features.Registration;

namespace Modules.Identity;
public static class IdentityModuleRouteBuilder
{
    public static IEndpointRouteBuilder MapIdentityRoutes(this IEndpointRouteBuilder builder)
    {
        builder.AddUserRegistrationEndpoint();
        return builder;
    }
}
