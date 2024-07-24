using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Core.Behaviours;
public static class MediatRBehaviourServiceCollectionExtensions
{
    public static IServiceCollection AddMediatRRequestLoggingBehaviour(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehaviour<,>));
        return services;
    }

    public static IServiceCollection AddMediatRFluentValidationBehaviour(this IServiceCollection services, List<Assembly> mediatRAssemblies)
    {
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        services.AddValidatorsFromAssemblies(mediatRAssemblies, includeInternalTypes: true);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
