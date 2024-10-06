using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Delete;
public sealed record DeleteQuestionCommand(long QuestionId) : ICommand<Result<bool>>;
