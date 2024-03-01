using MediatR;

namespace SharedKernel.Core;

public interface IDomainEvent : INotification
{
    Guid DomainId { get; }
    DateTimeOffset PublishedOn { get; }
}
