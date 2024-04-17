using System.Net;
using common;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Modules.Question.Application.Common;
using Modules.Question.Application.Question.QuestionSet.Create;
using Modules.Question.Application.Question.QuestionSet.Delete;
using Modules.Question.Application.Question.QuestionSet.Dtos;
using Modules.Question.Application.Question.QuestionSet.Query;
using Modules.Question.Application.Question.QuestionSet.Update;
using SharedKernel.Core;

namespace Modules.Question.Endpoints.QuestionSet;
internal class QuestionSet : IBaseEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder
            .MapGet(QuestionModuleConstants.Route.QuestionSetRoute.GetAllQuestionSets, GetAllQuestionSets)
            .Produces((int)HttpStatusCode.OK, typeof(PagedListDto<QuestionSetResponse>))
            .ProducesValidationProblem()
            .WithTags(QuestionModuleConstants.RouteTag.TagEndPointQuestionSetName)
            .RequireAuthorization();

        routeBuilder.MapGet(QuestionModuleConstants.Route.QuestionSetRoute.GetQuestionSetDetailsById, GetQuestionSetDetailsById)
            .Produces((int)HttpStatusCode.OK, typeof(QuestionSetResponse))
            .ProducesValidationProblem()
            .WithTags(QuestionModuleConstants.RouteTag.TagEndPointQuestionSetName)
            .RequireAuthorization();

        routeBuilder.MapPost(QuestionModuleConstants.Route.QuestionSetRoute.CreateQuestionSet, CreateQuestionSet)
            .Produces((int)HttpStatusCode.OK, typeof(QuestionSetResponse))
            .ProducesValidationProblem()
            .WithTags(QuestionModuleConstants.RouteTag.TagEndPointQuestionSetName)
            .RequireAuthorization();

        routeBuilder.MapPut(QuestionModuleConstants.Route.QuestionSetRoute.UpdateQuestionSet, UpdateQuestionSet)
            .Produces((int)HttpStatusCode.OK, typeof(QuestionSetResponse))
            .ProducesValidationProblem()
            .WithTags(QuestionModuleConstants.RouteTag.TagEndPointQuestionSetName)
            .RequireAuthorization();

        routeBuilder.MapDelete(QuestionModuleConstants.Route.QuestionSetRoute.DeleteQuestionSet, DeleteQuestionSet)
            .Produces((int)HttpStatusCode.OK, typeof(bool))
            .ProducesValidationProblem()
            .WithTags(QuestionModuleConstants.RouteTag.TagEndPointQuestionSetName)
            .RequireAuthorization();
    }

    private async Task<IResult> GetAllQuestionSets(ISender sender, [AsParameters] GetAllQuestionSetQuery query)
    {
        var sets = await sender.Send(query);
        return sets.ConvertToResult();
    }

    private static async Task<IResult> GetQuestionSetDetailsById(ISender sender, long setId)
    {
        var set = await sender.Send(new GetQuestionSetByIdQuery(setId));
        return set.ConvertToResult();
    }

    private static async Task<IResult> CreateQuestionSet(ISender sender, CreateQuestionSetCommand command)
    {
        var set = await sender.Send(command);

        return set.ConvertToResult();
    }

    private static async Task<IResult> UpdateQuestionSet(ISender sender, long setId, UpdateQuestionSetCommand command)
    {
        if (setId != command.QuestionSetId)
        {
            return Results.BadRequest("Invalid request");
        }
        var set = await sender.Send(command);
        return set.ConvertToResult();
    }

    private static async Task<IResult> DeleteQuestionSet(ISender sender, long setId)
    {
        var deleteSet = await sender.Send(new DeleteQuestionSetCommand(setId));

        return deleteSet.ConvertToResult();
    }
}
