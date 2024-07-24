using Microsoft.Extensions.DependencyInjection;
using Shared.Core;

namespace Shared.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterSharedInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<ITimeProvider, TimeProvider>();
        return services;
    }
}
