using System.Runtime.InteropServices.JavaScript;
using Shared.Core;

namespace Modules.Identity.Features.Profile;
internal record struct UserProfileError
{
    public static Error InvalidUserId => Error.NotFound("Identity.UserProfile", "Invalid user information");
}