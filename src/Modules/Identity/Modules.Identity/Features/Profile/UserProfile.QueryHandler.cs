using Microsoft.AspNetCore.Identity;
using Modules.Identity.Entities;
using SharedKernel.Core;

namespace Modules.Identity.Features.Profile;
internal sealed class UserProfileQueryHandler(IUser user,
    UserManager<ApplicationUser> userManager) : IQueryHandler<UserProfileQuery, Result<UserProfileResponse>>
{
    public async Task<Result<UserProfileResponse>> Handle(UserProfileQuery request, CancellationToken cancellationToken)
    {
        if (user.Id is null)
        {
            return UserProfileError.InvalidUserId;
        }
        var userDetails = await userManager.FindByIdAsync(user.Id);

        if (userDetails is null)
        {
            return UserProfileError.InvalidUserId;
        }

        var userRoles = await userManager.GetRolesAsync(userDetails);

        return new UserProfileResponse()
        {
            Email = userDetails.Email,
            LastName = userDetails.LastName,
            FirstName = userDetails.FirstName,
            UserId = userDetails.Id,
            Roles = userRoles
        };
    }
}
