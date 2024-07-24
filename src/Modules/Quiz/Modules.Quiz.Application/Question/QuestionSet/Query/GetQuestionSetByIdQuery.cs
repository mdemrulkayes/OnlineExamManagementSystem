using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Query;
public sealed record GetQuestionSetByIdQuery(long QuestionSetId) : IQuery<Result<QuestionSetResponse>>;