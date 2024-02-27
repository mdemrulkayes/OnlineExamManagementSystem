using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Modules.Identity.Constants;
using Modules.Identity.Features.Registration.Services;

namespace Modules.Identity.Features.Registration;
internal static class UserRegistrationEndpoint
{
    internal static IEndpointRouteBuilder AddUserRegistrationEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost(IdentityRouteConstants.Register, RegisterUser)
        .Produces<Ok>()
        .Produces<BadRequest>()
        .WithName("Register")
        .WithTags(IdentityRouteConstants.IdentityTagName)
        .WithOpenApi();

        return builder;
    }

    private static async Task<IResult> RegisterUser(UserRegistrationCommand command, IUserRegistrationService userRegistrationService)
    {
        var userRegistrationResult = await userRegistrationService.RegisterUser(command);
        return userRegistrationResult.Succeeded
            ? TypedResults.Ok()
            : TypedResults.BadRequest(userRegistrationResult.Errors.ToList());
    }
}
