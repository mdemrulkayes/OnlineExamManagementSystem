using AutoMapper;
using Modules.Quiz.Application.Question.Question.Dtos;
using Modules.Quiz.Core.QuestionAggregate;
using Shared.Application;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Query;
internal sealed class GetAllQuestionQueryHandler(IQuestionRepository repository, IMapper mapper)
    : IQueryHandler<GetAllQuestionQuery, Result<PagedListDto<QuestionResponse>>>
{
    public async Task<Result<PagedListDto<QuestionResponse>>> Handle(GetAllQuestionQuery request, CancellationToken cancellationToken)
    {
        var sets = await repository.GetAllAsync(pageNumber: request.PageNumber, pageSize: request.PageSize,
            cancellationToken: cancellationToken);

        return mapper.Map<PagedListDto<QuestionResponse>>(sets);
    }
}
