using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Create;

public sealed record CreateQuestionSetCommand(string Name, string? SetCode , string? Details) : ICommand<Result<QuestionSetResponse>>;
