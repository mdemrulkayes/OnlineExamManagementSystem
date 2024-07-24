using Shared.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Delete;
public sealed record DeleteQuestionSetCommand(long QuestionSetId) : ICommand<Result<bool>>;
