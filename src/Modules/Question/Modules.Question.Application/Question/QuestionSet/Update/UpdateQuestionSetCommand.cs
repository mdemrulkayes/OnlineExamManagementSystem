using Modules.Question.Application.Question.QuestionSet.Dtos;
using SharedKernel.Core;

namespace Modules.Question.Application.Question.QuestionSet.Update;

public sealed record UpdateQuestionSetCommand(long QuestionSetId, string Name, string? SetCode, string? Details) : ICommand<Result<QuestionSetResponse>>;
