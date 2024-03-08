namespace Modules.Identity.Features.Profile;
internal sealed class UserProfileResponse
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; }
    public IList<string> Roles { get; set; }
}
