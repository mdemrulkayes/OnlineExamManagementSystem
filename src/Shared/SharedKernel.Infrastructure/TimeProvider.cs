using SharedKernel.Core;

namespace SharedKernel.Infrastructure;
internal class TimeProvider : ITimeProvider
{
    public DateTimeOffset TimeNow => DateTimeOffset.UtcNow;
}
