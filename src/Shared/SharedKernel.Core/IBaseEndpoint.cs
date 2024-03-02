using Microsoft.AspNetCore.Routing;

namespace SharedKernel.Core;
public interface IBaseEndpoint
{
    void MapEndpoints(IEndpointRouteBuilder routeBuilder);
}
