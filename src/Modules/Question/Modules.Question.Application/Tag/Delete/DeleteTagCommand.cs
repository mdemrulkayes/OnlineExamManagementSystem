using SharedKernel.Core;

namespace Modules.Question.Application.Tag.Delete;
public sealed record DeleteTagCommand(long TagId) : ICommand<Result<bool>>;
