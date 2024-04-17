using Modules.Question.Application.Tag.Dtos;
using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Create;

public sealed record CreateTagCommand(string Name, string Description) : ICommand<Result<TagResponse>>;
