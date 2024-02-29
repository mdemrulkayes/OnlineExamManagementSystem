using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Identity.Constants;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration;
internal static class UserRegistrationEndpoint
{
    internal static IEndpointRouteBuilder AddUserRegistrationEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost(IdentityModuleConstants.Route.Register, RegisterUser)
        .WithName(nameof(IdentityModuleConstants.Route.Register))
        .WithTags(IdentityModuleConstants.RouteTag.IdentityTagName)
        .WithOpenApi();

        return builder;
    }

    private static async Task<IResult> RegisterUser(UserRegistrationCommand command, IMediator mediator)
    {
        var userRegistrationResult = await mediator.Send(command);
        return userRegistrationResult.IsSuccess
            ? TypedResults.Ok()
            : userRegistrationResult.ConvertToProblemDetails();
    }
}
