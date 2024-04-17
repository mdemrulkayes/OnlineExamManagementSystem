using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Modules.Question.Application;
using Modules.Question.Infrastructure;
using Serilog;

namespace Modules.Question.Endpoints;
public static class QuestionModuleEndpointsServiceCollectionExtension
{
    public static IServiceCollection RegisterQuestionModule(this IServiceCollection services,
        IConfiguration configuration,
        ILogger logger,
        List<Assembly> mediatRAssembly)
    {
        mediatRAssembly.Add(typeof(QuestionModuleEndpointsServiceCollectionExtension).Assembly);
        services.RegisterQuestionModuleApplication(mediatRAssembly);
        services.RegisterQuestionModuleInfrastructure(logger, configuration, mediatRAssembly);
        return services;
    }


}
