using System.Diagnostics;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Shared.Core.Behaviours;
internal sealed class RequestLoggingBehaviour<TRequest, TResponse>(ILogger<RequestLoggingBehaviour<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
where TRequest : notnull
where TResponse : IBaseResult
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken = default)
    {
        var requestName = typeof(TRequest).Name;
        if (logger.IsEnabled(LogLevel.Information))
        {
            logger.LogInformation("Handling {RequestName}", requestName);

            var requestType = request.GetType();
            var props = new List<PropertyInfo>(requestType.GetProperties());
            foreach (var propertyInfo in props)
            {
                var propValue = propertyInfo?.GetValue(request, null);
                logger.LogInformation("Property {PropertyName}: {PropertyValue}", propertyInfo?.Name, propValue);
            }
        }

        var stopWatch = Stopwatch.StartNew();

        var response = await next();

        logger.LogInformation("Handled {RequestName} with {Response} in {ms} ms", requestName, response, stopWatch.ElapsedMilliseconds);
        stopWatch.Stop();

        if (response.IsSuccess) return response;
        using (LogContext.PushProperty("@Error", response.Error, true))
        {
            logger.LogError("{RequestName} completed with error", requestName);
        }

        return response;
    }
}
