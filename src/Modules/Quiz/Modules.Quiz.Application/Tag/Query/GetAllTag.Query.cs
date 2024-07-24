using Modules.Quiz.Application.Tag.Dtos;
using Shared.Application;
using Shared.Core;

namespace Modules.Quiz.Application.Tag.Query;

public sealed record GetAllTagQuery : QueryStringParameter, IQuery<Result<PagedListDto<TagResponse>>>;
