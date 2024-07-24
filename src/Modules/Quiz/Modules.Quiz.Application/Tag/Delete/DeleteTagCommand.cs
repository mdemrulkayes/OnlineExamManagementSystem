using SharedKernel.Core;

namespace Modules.Quiz.Application.Tag.Delete;
public sealed record DeleteTagCommand(long TagId) : ICommand<Result<bool>>;
