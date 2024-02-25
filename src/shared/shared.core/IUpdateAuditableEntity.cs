namespace shared.core;
public interface IUpdateAuditableEntity
{
    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
