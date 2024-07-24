using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Identity.Constants;
using Shared.Core;

namespace Modules.Identity.Features.Profile;
internal sealed class UserProfile : IBaseEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet(IdentityModuleConstants.Route.Profile, GetUserProfileDetails)
            .WithTags(IdentityModuleConstants.RouteTag.IdentityTagName)
            .RequireAuthorization();
    }

    private async Task<IResult> GetUserProfileDetails(ISender sender)
    {
        var userDetails = await sender.Send(new UserProfileQuery());
        return userDetails.IsSuccess ?
            TypedResults.Ok(userDetails.Value) :
            userDetails.ConvertToProblemDetails();
    }
}
