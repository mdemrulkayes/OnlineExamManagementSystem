using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Core;

namespace SharedKernel.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterSharedInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<ITimeProvider, TimeProvider>();
        return services;
    }
}
