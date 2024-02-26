namespace SharedKernel.Core;
public interface ITimeProvider
{
    DateTimeOffset TimeNow { get; }
}
