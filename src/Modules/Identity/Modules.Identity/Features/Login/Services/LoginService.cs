using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Modules.Identity.Entities;
using SharedKernel.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Modules.Identity.Features.Login.Services;
internal sealed class LoginService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    IOptions<JwtConfiguration> jwtConfigurationOptions,
    ILogger<LoginService> logger) : ILoginService
{
    public async Task<Result<LoginResponse>> Login(LoginCommand command)
    {
        logger.LogInformation("Inside the login method");
        var signIn = await signInManager.PasswordSignInAsync(command.Email, command.Password, false, false);

        if (!signIn.Succeeded)
        {
            return LoginErrors.InvalidCredential;
        }

        var loginResponse = await GenerateJwtToken(command.Email);
        if (!loginResponse.IsSuccess || loginResponse.Value is null)
        {
            return LoginErrors.InvalidCredential;
        }

        return loginResponse.Value;
    }


    private async Task<Result<LoginResponse>> GenerateJwtToken(string email)
    {
        var userDetails = await userManager.FindByEmailAsync(email);

        if (userDetails == null)
        {
            logger.LogError("User details not found with the email: {Email}", email);
            return LoginErrors.InvalidCredential;
        }

        var (jwtKey, expireDays, jwtIssuer, jwtAudience) = jwtConfigurationOptions.Value;
        var claims = new List<Claim>();
        if (userDetails.Email is not null)
        {
            claims.Add(new(ClaimTypes.Email, userDetails.Email));
        }

        var userRoles = userManager.GetRolesAsync(userDetails).Result.ToList();
        if (!userRoles.Any())
        {
            logger.LogError("User with guid {UserGuid} is not associated with any role", userDetails.Id);
        }

        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        claims.Add(new Claim("UserId", userDetails.Id.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddDays(Convert.ToInt32(expireDays));

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtIssuer,
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
