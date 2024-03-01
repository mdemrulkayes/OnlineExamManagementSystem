using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Modules.Identity.Constants;
using Modules.Identity.Entities;
using Modules.Identity.Features.Registration.Enums;
using Modules.Identity.Features.Registration.Events;
using SharedKernel.Core;

namespace Modules.Identity.Features.Registration.Services;
internal class UserRegistrationService(
    UserManager<ApplicationUser> userManager,
    ITimeProvider timeProvider,
    ILogger<UserRegistrationService> logger,
    IMediator mediator
    ) : IUserRegistrationService
{
    public async Task<Result<bool>> RegisterUser(UserRegistrationCommand command)
    {
        var user = ApplicationUser.RegisterUser(command.FirstName, command.LastName, command.Email, command.PhoneNumber, command.UserType, timeProvider);
        if (!user.IsSuccess || user.Value is null)
        {
            return user.Error;
        }
        logger.LogInformation("Application user instance created to register user");
        var result = await userManager.CreateAsync(user.Value, command.Password);
        if (!result.Succeeded)
        {
            return RegistrationErrors.IdentityError(result.Errors);
        }
        await AssignToRole(user.Value);

        await mediator.Publish(new SendWelcomeEmailAfterUserRegistered(user.Value.FirstName, user.Value.LastName,
            user.Value.Email, "Welcome to the Quizzer", timeProvider));

        return result.Succeeded;
    }

    public async Task<ApplicationUser?> GetUserDetailsByEmail(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    #region Private methods

    private async Task AssignToRole(ApplicationUser user)
    {
        var roleName = user.UserType switch
        {
            UserType.QuizAuthor => RoleConstants.QuizAuthor,
            UserType.Examine => RoleConstants.Examine,
            _ => ""
        };
        if (!string.IsNullOrWhiteSpace(roleName))
        {
            var roleAssignResult = await userManager.AddToRoleAsync(user, roleName);
            if (!roleAssignResult.Succeeded)
            {
                logger.LogCritical("User created successfully but can not assign to role.");
            }
        }
        else
        {
            logger.LogError("Invalid role to assign a registered user");
        }
    }

    #endregion
}
