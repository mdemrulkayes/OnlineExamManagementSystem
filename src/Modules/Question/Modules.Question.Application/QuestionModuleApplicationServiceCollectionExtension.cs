using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Modules.Question.Application;
public static class QuestionModuleApplicationServiceCollectionExtension
{
    public static IServiceCollection RegisterQuestionModuleApplication(this IServiceCollection services, List<Assembly> mediatRAssembly)
    {
        mediatRAssembly.Add(typeof(QuestionModuleApplicationServiceCollectionExtension).Assembly);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
