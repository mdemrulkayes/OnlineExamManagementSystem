using Modules.Quiz.Application.Tag.Dtos;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Tag.Query;
public sealed record GetTagByIdQuery(long TagId) : IQuery<Result<TagResponse>>;