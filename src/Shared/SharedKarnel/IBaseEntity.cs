namespace SharedKernel.Core;

public interface IBaseEntity
{
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    void ClearDomainEvents();
}
