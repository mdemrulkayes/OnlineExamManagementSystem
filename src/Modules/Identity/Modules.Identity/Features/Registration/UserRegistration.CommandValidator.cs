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
            .NotNull()
            .NotEmpty()
            .WithMessage("First name can not be empty");

        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Last name can not be empty");

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email can not be empty")
            .EmailAddress()
            .WithMessage("Invalid email address")
            .MustAsync(async (email, _) => !await IsUserAlreadyExistsWithTheSameEmail(email));

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .WithMessage("Phone number can not be empty");

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("Password is required");

        RuleFor(x => x.ConfirmPassword)
            .NotNull()
            .NotEmpty()
            .WithMessage("Confirm password can not be empty")
            .Matches(x => x.Password)
            .WithMessage("Password and Confirm password does not match");

        RuleFor(x => x.UserType)
            .NotNull()
            .IsInEnum();
    }

    private async Task<bool> IsUserAlreadyExistsWithTheSameEmail(string email)
    {
        return await _userRegistrationService.GetUserDetailsByEmail(email) is not null;
    }}
