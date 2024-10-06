using Modules.Quiz.Application.Question.Question.Dtos;
using Shared.Application;
using Shared.Core;

namespace Modules.Quiz.Application.Question.Question.Query;

public sealed record GetAllQuestionQuery : QueryStringParameter, IQuery<Result<PagedListDto<QuestionResponse>>>;
