using Modules.Question.Application.Tag.Dtos;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Update;

public sealed record UpdateTagCommand(long TagId, string Name, string Description) : ICommand<Result<TagResponse>>;
