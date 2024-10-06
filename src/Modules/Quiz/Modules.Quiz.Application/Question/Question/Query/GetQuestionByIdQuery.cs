using Modules.Quiz.Application.Question.Question.Dtos;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Query;
public sealed record GetQuestionByIdQuery(long QuestionId) : IQuery<Result<QuestionResponse>>;