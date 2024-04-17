using SharedKernel.Core;

namespace Modules.Question.Application.Question.QuestionSet.Delete;
public sealed record DeleteQuestionSetCommand(long QuestionSetId) : ICommand<Result<bool>>;
