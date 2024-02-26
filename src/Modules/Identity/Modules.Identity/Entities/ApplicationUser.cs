using Microsoft.AspNetCore.Identity;
using Modules.Identity.Enums;
using SharedKernel.Core;

namespace Modules.Identity.Entities;
public sealed class ApplicationUser : IdentityUser<Guid>, IBaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTimeOffset DeletedDate { get; set; }
}
