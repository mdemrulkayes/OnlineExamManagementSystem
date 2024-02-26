using Microsoft.AspNetCore.Identity;
using Modules.Identity.Enums;
using SharedKernel.Core;

namespace Modules.Identity.Entities;
public sealed class ApplicationUser : IdentityUser<Guid>, IBaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public bool? IsDeleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTimeOffset DeletedDate { get; set; }

    private ApplicationUser(string firstName, string lastName, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = UserName = NormalizedEmail = NormalizedUserName = email;
        PhoneNumber = phoneNumber;
        EmailConfirmed = false;
        PhoneNumberConfirmed = false;
    }

    public static ApplicationUser RegisterUser(string firstName, string lastName, string email, string phoneNumber)
    {
        return new ApplicationUser(firstName, lastName, email, phoneNumber);
    }
}
