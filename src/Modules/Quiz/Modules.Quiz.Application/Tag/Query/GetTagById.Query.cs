using Modules.Quiz.Application.Tag.Dtos;
using Shared.Core;

namespace Modules.Quiz.Application.Tag.Query;
public sealed record GetTagByIdQuery(long TagId) : IQuery<Result<TagResponse>>;