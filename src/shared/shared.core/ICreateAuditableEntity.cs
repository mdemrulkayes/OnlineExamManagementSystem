namespace shared.core;
public interface ICreateAuditableEntity
{
    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
}
