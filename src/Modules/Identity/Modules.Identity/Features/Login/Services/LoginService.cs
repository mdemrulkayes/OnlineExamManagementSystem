using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Modules.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Core;

namespace Modules.Identity.Features.Login.Services;
internal sealed class LoginService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IOptions<JwtConfiguration> jwtConfigurationOptions,
    ILogger<LoginService> logger,
    ITimeProvider timeProvider) : ILoginService
{
    public async Task<Result<LoginResponse>> Login(LoginCommand command)
    {
        logger.LogInformation("Inside the login method");
        var userDetails = await userManager.FindByEmailAsync(command.Email);

        if (userDetails == null)
        {
            logger.LogError("User details not found with the email: {Email}", command.Email);
            return LoginErrors.InvalidCredential;
        }

        var signIn = await signInManager.CheckPasswordSignInAsync(userDetails, command.Password, false);

        if (!signIn.Succeeded)
        {
            return LoginErrors.InvalidCredential;
        }

        var loginResponse = GenerateJwtToken(command.Email, userDetails);
        if (!loginResponse.IsSuccess || loginResponse.Value is null)
        {
            return LoginErrors.InvalidCredential;
        }

        await UpdateUserLastLogin(userDetails);

        return loginResponse.Value;
    }

    private async Task UpdateUserLastLogin(ApplicationUser user)
    {
        try
        {
            user.UpdateLastLoginTime(timeProvider);

            await userManager.UpdateAsync(user);
        }
        catch (Exception e)
        {
            logger.LogError("Error occurred while saving user last login information. UserGuid: {userGuid}", user.Id);
            logger.LogError("Exception {exception}", e);
        }
    }


    private Result<LoginResponse> GenerateJwtToken(string email, ApplicationUser userDetails)
    {
        var jwtConfiguration = jwtConfigurationOptions.Value;
        var claims = new List<Claim>();
        if (userDetails.Email is not null)
        {
            claims.Add(new(JwtRegisteredClaimNames.Email, userDetails.Email));
            claims.Add(new(JwtRegisteredClaimNames.Sub, userDetails.Email));
        }

        var userRoles = userManager.GetRolesAsync(userDetails).Result.ToList();
        if (!userRoles.Any())
        {
            logger.LogError("User with guid {UserGuid} is not associated with any role", userDetails.Id);
        }

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        claims.Add(new Claim("UserId", userDetails.Id.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.JwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var expires = DateTime.UtcNow.AddDays(Convert.ToInt32(jwtConfiguration.JwtExpireDay));

        var token = new JwtSecurityToken(
            issuer: jwtConfiguration.JwtIssuer,
            audience: jwtConfiguration.JwtAudience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
        logger.LogInformation("Token generated successfully");
        return new LoginResponse(userDetails.Id.ToString(), userDetails.Email,
            $"{userDetails.FirstName} {userDetails.LastName}", generatedToken);
    }
}
