using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Core;

namespace SharedKernel.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterSharedInfrastructure(this IServiceCollection services)
    {
        return services.AddScoped<ITimeProvider, TimeProvider>();
    }
}
