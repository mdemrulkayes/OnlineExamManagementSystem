using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Entities;

namespace Quizzer.Api.FunctionalTest.Abstraction;
public class QuizzerBaseFunctionTest 
    : IClassFixture<QuizzerWebApiFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected readonly HttpClient HttpClient;
    protected readonly UserManager<ApplicationUser> UserManager;

    public QuizzerBaseFunctionTest(QuizzerWebApiFactory factory)
    {
        _scope = factory.Services.CreateScope();
        HttpClient = factory.CreateClient();
        UserManager = _scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    }

    public void Dispose()
    {
        _scope.Dispose();
        HttpClient.Dispose();
        UserManager.Dispose();
    }
}
