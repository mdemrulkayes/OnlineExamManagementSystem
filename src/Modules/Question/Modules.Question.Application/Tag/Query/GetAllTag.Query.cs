using common;
using Modules.Question.Application.Tag.Dtos;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Query;

public sealed record GetAllTagQuery : QueryStringParameter, IQuery<Result<PagedListDto<TagResponse>>>;
