using AutoMapper;
using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using Modules.Quiz.Core.QuestionAggregate;
using Shared.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Create;
internal sealed class CreateQuestionSetCommandHandler(IQuestionSetRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateQuestionSetCommand, Result<QuestionSetResponse>>
{
    /// <summary>Handles a request</summary>
    /// <param name="command">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<Result<QuestionSetResponse>> Handle(CreateQuestionSetCommand command, CancellationToken cancellationToken)
    {
        var questionSet = Core.QuestionAggregate.QuestionSet.Create(command.Name, command.SetCode, command.Details);

        if (!questionSet.IsSuccess || questionSet.Value is null)
        {
            return questionSet.Error;
        }

        var set = questionSet.Value;

        repository.Add(set);
        await unitOfWork.CommitAsync(cancellationToken);

        return mapper.Map<Core.QuestionAggregate.QuestionSet, QuestionSetResponse>(set);
    }
}
