using AutoMapper;
using Modules.Quiz.Application.Question.Question.Dtos;
using Modules.Quiz.Core.QuestionAggregate;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Update;
internal sealed class UpdateQuestionCommandHandler(IQuestionRepository repository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : ICommandHandler<UpdateQuestionCommand, Result<QuestionResponse>>
{
    public async Task<Result<QuestionResponse>> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken = default)
    {
        var question = await repository.FirstOrDefaultAsync(x => x.QuestionId == request.QuestionId);
        if (question == null)
        {
            return QuestionErrors.QuestionNotFound;
        }

        var updateQuestionResult = question.Update(request.Question, request.Details, request.Mark);

        if (!updateQuestionResult.IsSuccess || updateQuestionResult.Value is null)
        {
            return updateQuestionResult.Error;
        }

        repository.Update(updateQuestionResult.Value);
        await unitOfWork.CommitAsync(cancellationToken);

        return mapper.Map<QuestionResponse>(updateQuestionResult.Value);
    }
}
