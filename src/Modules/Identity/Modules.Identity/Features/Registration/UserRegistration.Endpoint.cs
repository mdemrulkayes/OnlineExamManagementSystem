using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Modules.Identity.Constants;
using Modules.Identity.Features.Registration.Services;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration;
internal static class UserRegistrationEndpoint
{
    internal static IEndpointRouteBuilder AddUserRegistrationEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost(IdentityModuleConstants.Route.Register, RegisterUser)
        .Produces<Ok>()
        .WithName(nameof(IdentityModuleConstants.Route.Register))
        .WithTags(IdentityModuleConstants.RouteTag.IdentityTagName)
        .WithOpenApi();

        return builder;
    }

    private static async Task<IResult> RegisterUser(UserRegistrationCommand command, IUserRegistrationService userRegistrationService)
    {
        var userRegistrationResult = await userRegistrationService.RegisterUser(command);
        return userRegistrationResult.IsSuccess
            ? TypedResults.Ok()
            : userRegistrationResult.ConvertToProblemDetails();
    }
}
