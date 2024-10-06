using Modules.Quiz.Application.Question.Question.Dtos;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Update;

public sealed record UpdateQuestionCommand(long QuestionId, string Question, string Details, int? Mark) : ICommand<Result<QuestionResponse>>;
