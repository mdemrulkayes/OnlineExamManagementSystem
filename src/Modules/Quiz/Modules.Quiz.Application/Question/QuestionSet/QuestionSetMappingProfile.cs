using AutoMapper;
using Modules.Quiz.Application.Question.QuestionSet.Dtos;

namespace Modules.Quiz.Application.Question.QuestionSet;
internal sealed class QuestionSetMappingProfile : Profile
{
    public QuestionSetMappingProfile()
    {
        CreateMap<Core.QuestionAggregate.QuestionSet, QuestionSetResponse>()
            .ConstructUsing(set => new QuestionSetResponse(
                set.QuestionSetId,
                set.Name,
                set.SetCode,
                set.Details
            ))
            .ReverseMap();
    }
}
