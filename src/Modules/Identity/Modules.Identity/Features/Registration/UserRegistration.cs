using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Features.Registration.Services;

namespace Modules.Identity.Features.Registration;

internal static class UserRegistration
{
    internal static IServiceCollection RegisterUserRegistrationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRegistrationService, UserRegistrationService>();
        return services;
    }
}
