using Modules.Quiz.Application.Question.QuestionSet.Dtos;
using Shared.Application;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Question.QuestionSet.Query;

public sealed record GetAllQuestionSetQuery : QueryStringParameter, IQuery<Result<PagedListDto<QuestionSetResponse>>>;
