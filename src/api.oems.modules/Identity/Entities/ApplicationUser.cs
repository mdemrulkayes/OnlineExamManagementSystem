using api.oems.modules.Identity.Enums;
using Microsoft.AspNetCore.Identity;
using shared.core;

namespace api.oems.modules.Identity.Entities;

public class ApplicationUser : IdentityUser, IAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
