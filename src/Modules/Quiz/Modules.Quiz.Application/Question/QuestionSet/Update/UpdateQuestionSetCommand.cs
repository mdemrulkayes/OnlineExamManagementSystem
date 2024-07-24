using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using Shared.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Update;

public sealed record UpdateQuestionSetCommand(long QuestionSetId, string Name, string? SetCode, string? Details) : ICommand<Result<QuestionSetResponse>>;
