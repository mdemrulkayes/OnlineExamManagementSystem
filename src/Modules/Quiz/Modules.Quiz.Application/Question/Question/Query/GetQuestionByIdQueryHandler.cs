using AutoMapper;
using Modules.Quiz.Application.Question.Question.Dtos;
using Modules.Quiz.Core.QuestionAggregate;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Query;
internal class GetQuestionByIdQueryHandler(IQuestionRepository repository,
    IMapper mapper) : IQueryHandler<GetQuestionByIdQuery, Result<QuestionResponse>>
{
    public async Task<Result<QuestionResponse>> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var questionDetails = await repository.FirstOrDefaultAsync(x => x.QuestionId == request.QuestionId);
        if (questionDetails == null)
        {
            return QuestionErrors.QuestionNotFound;
        }

        return mapper.Map<QuestionResponse>(questionDetails);
    }
}
