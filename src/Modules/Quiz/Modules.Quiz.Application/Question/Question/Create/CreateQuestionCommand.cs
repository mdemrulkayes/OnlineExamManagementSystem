using Modules.Quiz.Application.Question.Question.Dtos;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Create;

public sealed record CreateQuestionCommand(string Question, string Details, int? Mark) : ICommand<Result<QuestionResponse>>;
