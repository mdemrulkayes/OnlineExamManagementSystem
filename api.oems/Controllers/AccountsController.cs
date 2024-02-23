using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Account;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.oems.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtAuthenticationTokenRepository _jwtAuthenticationTokenRepository;

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtAuthenticationTokenRepository jwtAuthenticationTokenRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtAuthenticationTokenRepository = jwtAuthenticationTokenRepository;
        }

        [HttpPost]
        [ActionName("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginResources loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDetails = await _userManager.FindByEmailAsync(loginResource.Email);

            if (userDetails == null)
            {
                return BadRequest("Invalid Login attempt");
            }

            var signIn = await _signInManager.PasswordSignInAsync(userDetails, loginResource.Password, false, false);
            if (signIn.Succeeded)
            {
                if (userDetails.EmailConfirmed)
                {
                    var token = _jwtAuthenticationTokenRepository.GenerateJwtToken(userDetails);
                    var response = new LoginResponse(){UserId = userDetails.Id, auth_token =  token,
                        Name = $"{userDetails.FirstName} {userDetails.LastName}", Email = userDetails.Email.ToLower()};
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Please confirm your account");
                }
            }
            else
            {
                return BadRequest("Invalid Username or password");
            }
        }


        [HttpPost]
        [ActionName("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterResources registerResource)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userDetails = await _userManager.FindByEmailAsync(registerResource.Email);

            if (userDetails != null)
            {
                return BadRequest("Email is already in use");
            }
            var user = new ApplicationUser()
            {
                UserName = registerResource.Email,
                Email = registerResource.Email,
                NormalizedEmail = registerResource.Email,
                NormalizedUserName = registerResource.Email,
                FirstName = registerResource.FirstName,
                LastName = registerResource.LastName,
                PhoneNumber = registerResource.PhoneNumber,
                EmailConfirmed = false,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, registerResource.Password);
            if (result.Succeeded)
            {
                var addRole = await _userManager.AddToRoleAsync(user, "Student");
                if (addRole.Succeeded)
                {
                    return Ok(user);
                }

                return BadRequest("User created Successfully but Role can not be created");
            }
            
            var sb = new StringBuilder();
            foreach (var error in result.Errors)
            {
                sb.Append(error.Description);
                sb.Append("\n");
            }

            return BadRequest(sb.ToString());
        }
    }
}