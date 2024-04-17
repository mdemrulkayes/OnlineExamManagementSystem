using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Question.Application.Common;
using Modules.Question.Application.Tag.Query;
using SharedKernel.Core;

namespace Modules.Question.Endpoints.Tag;
internal class Tag : IBaseEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet(QuestionModuleConstants.Route.Tag, GetAllTags)
            .WithTags(QuestionModuleConstants.RouteTag.TagEndPointTagName)
            .RequireAuthorization();
    }

    private async Task<IResult> GetAllTags(ISender sender, [AsParameters] GetAllTagQuery query)
    {
        var allTags = await sender.Send(query);
        return allTags.IsSuccess ? TypedResults.Ok(allTags.Value) : allTags.ConvertToProblemDetails();
    }
}
