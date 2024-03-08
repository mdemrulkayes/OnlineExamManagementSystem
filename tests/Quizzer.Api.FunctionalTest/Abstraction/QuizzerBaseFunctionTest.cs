using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Modules.Identity.Entities;
using Modules.Identity.Features.Registration.Enums;
using Modules.Identity.Features.Registration;
using Modules.Identity.Constants;
using System.Net.Http.Json;
using Modules.Identity.Features.Login;

namespace Quizzer.Api.FunctionalTest.Abstraction;
public class QuizzerBaseFunctionTest
    : IClassFixture<QuizzerWebApiFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected readonly HttpClient HttpClient;
    protected readonly UserManager<ApplicationUser> UserManager;
    public Dictionary<string, string> LoggedInUserDictionary = new();

    public QuizzerBaseFunctionTest(QuizzerWebApiFactory factory)
    {
        _scope = factory.Services.CreateScope();
        HttpClient = factory.CreateClient();
        UserManager = _scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    }

    public async Task RegisterOneTimeUser()
    {
        foreach (var registrationCommand in GenerateRegisterUserCommand())
        {
            await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Register, registrationCommand);
        }
    }

    public async Task LoginOneTimeUser()
    {
        foreach (var loginCommand in GenerateRegisterUserCommand())
        {
            var loginApiCall = await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Login, loginCommand);
            var content = await loginApiCall.Content.ReadFromJsonAsync<LoginResponse>();

            LoggedInUserDictionary.Add(loginCommand.Email, content.Token);
        }
    }

    private static List<UserRegistrationCommand> GenerateRegisterUserCommand()
    {
        return
        [
            new UserRegistrationCommand("test", "one", "test1@gmail.com", "144574745", "Aa123456#", "Aa123456#",
                UserType.Examine),

            new UserRegistrationCommand("test", "two", "test2@gmail.com", "144574745", "Aa123456!", "Aa123456!",
                UserType.QuizAuthor),

            new UserRegistrationCommand("test", "three", "test3@gmail.com", "144574745", "Aa123456%", "Aa123456%",
                UserType.QuizAuthor)
        ];
    }

    public void Dispose()
    {
        LoggedInUserDictionary.Clear();
        LoggedInUserDictionary = new();
        _scope.Dispose();
        HttpClient.Dispose();
        UserManager.Dispose();
    }
}
