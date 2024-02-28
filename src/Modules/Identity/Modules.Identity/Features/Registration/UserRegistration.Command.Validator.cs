using FluentValidation;
using Modules.Identity.Features.Registration.Services;

namespace Modules.Identity.Features.Registration;
internal sealed class UserRegistrationCommandValidator : AbstractValidator<UserRegistrationCommand>
{
    private readonly IUserRegistrationService _userRegistrationService;
    public UserRegistrationCommandValidator(IUserRegistrationService userRegistrationService)
    {
        _userRegistrationService = userRegistrationService;
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name can not be empty");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name can not be empty");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email can not be empty")
            .EmailAddress()
            .WithMessage("Invalid email address")
            .MustAsync(async (email, _) => !await IsUserAlreadyExistsWithTheSameEmail(email));

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number can not be empty");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password can not be empty")
            .Matches(x => x.Password)
            .WithMessage("Password and Confirm password does not match");

        RuleFor(x => x.UserType)
            .IsInEnum();
    }

    private async Task<bool> IsUserAlreadyExistsWithTheSameEmail(string email)
    {
        return await _userRegistrationService.GetUserDetailsByEmail(email) is not null;
    }}
