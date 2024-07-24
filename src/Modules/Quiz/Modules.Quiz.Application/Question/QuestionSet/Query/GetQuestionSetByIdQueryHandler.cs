using AutoMapper;
using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using Modules.Quiz.Core.QuestionAggregate;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Query;
internal class GetQuestionSetByIdQueryHandler(IQuestionSetRepository repository,
    IMapper mapper) : IQueryHandler<GetQuestionSetByIdQuery, Result<QuestionSetResponse>>
{
    public async Task<Result<QuestionSetResponse>> Handle(GetQuestionSetByIdQuery request, CancellationToken cancellationToken)
    {
        var setDetails = await repository.FirstOrDefaultAsync(x => x.QuestionSetId == request.QuestionSetId);
        if (setDetails == null)
        {
            return QuestionErrors.QuestionSetNotFound;
        }

        return mapper.Map<QuestionSetResponse>(setDetails);
    }
}
