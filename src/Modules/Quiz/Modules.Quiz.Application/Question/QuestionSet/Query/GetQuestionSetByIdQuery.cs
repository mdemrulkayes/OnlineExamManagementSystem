using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using Shared.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Query;
public sealed record GetQuestionSetByIdQuery(long QuestionSetId) : IQuery<Result<QuestionSetResponse>>;