using AutoMapper;
using Modules.Quiz.Application.Question.Question.Dtos;
using Modules.Quiz.Core.QuestionAggregate;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Create;
internal sealed class CreateQuestionCommandHandler(IQuestionRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateQuestionCommand, Result<QuestionResponse>>
{
    /// <summary>Handles a request</summary>
    /// <param name="command">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<Result<QuestionResponse>> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
    {
        var questionResult = Core.QuestionAggregate.Question.Create(command.Question, command.Details, command.Mark);

        if (!questionResult.IsSuccess || questionResult.Value is null)
        {
            return questionResult.Error;
        }

        var question = questionResult.Value;

        repository.Add(question);
        await unitOfWork.CommitAsync(cancellationToken);

        return mapper.Map<Core.QuestionAggregate.Question, QuestionResponse>(question);
    }
}
