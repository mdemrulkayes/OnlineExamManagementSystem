namespace SharedKernel.Core;
public interface IBaseAuditableEntity :
    ICreatedAuditableEntity,
    IUpdatedAuditableEntity;