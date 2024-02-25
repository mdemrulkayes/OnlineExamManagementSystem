namespace shared.core;
public interface IDeleteAuditableEntity
{
    public bool? IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedAt { get; set; }
}
