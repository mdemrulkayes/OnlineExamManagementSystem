using Modules.Question.Application.Question.QuestionSet.Dtos;
using SharedKernel.Core;

namespace Modules.Question.Application.Question.QuestionSet.Create;

public sealed record CreateQuestionSetCommand(string Name, string? SetCode , string? Details) : ICommand<Result<QuestionSetResponse>>;
