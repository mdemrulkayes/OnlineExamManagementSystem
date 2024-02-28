namespace SharedKernel.Core;
public interface IUpdatedAuditableEntity
{
    public Guid? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
}
