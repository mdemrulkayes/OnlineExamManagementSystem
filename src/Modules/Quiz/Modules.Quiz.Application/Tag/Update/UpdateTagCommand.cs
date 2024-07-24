using Modules.Quiz.Application.Tag.Dtos;
using SharedKernel.Core;

namespace Modules.Quiz.Application.Tag.Update;

public sealed record UpdateTagCommand(long TagId, string Name, string Description) : ICommand<Result<TagResponse>>;
