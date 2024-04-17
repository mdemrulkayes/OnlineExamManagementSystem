using Modules.Question.Application.Tag.Dtos;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Query;
public sealed record GetTagByIdQuery(long TagId) : IQuery<Result<TagResponse>>;