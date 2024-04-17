using AutoMapper;
using common;
using Modules.Question.Application.Question.QuestionSet.Dtos;
using Modules.Question.Core.QuestionAggregate;
using SharedKernel.Core;

namespace Modules.Question.Application.Question.QuestionSet.Query;
internal sealed class GetAllQuestionSetQueryHandler(IQuestionSetRepository repository, IMapper mapper)
    : IQueryHandler<GetAllQuestionSetQuery, Result<PagedListDto<QuestionSetResponse>>>
{
    public async Task<Result<PagedListDto<QuestionSetResponse>>> Handle(GetAllQuestionSetQuery request, CancellationToken cancellationToken)
    {
        var sets = await repository.GetAllAsync(pageNumber: request.PageNumber, pageSize: request.PageSize,
            cancellationToken: cancellationToken);

        return mapper.Map<PagedListDto<QuestionSetResponse>>(sets);
    }
}
