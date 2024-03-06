using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Modules.Identity.Constants;
using Modules.Identity.Features.Login;
using Modules.Identity.Features.Registration;
using Modules.Identity.Features.Registration.Enums;
using Quizzer.Api.FunctionalTest.Abstraction;

namespace Quizzer.Api.FunctionalTest.Modules.Identity.Features.Login;

public class LoginEndpointTest(QuizzerWebApiFactory factory) : QuizzerBaseFunctionTest(factory)
{
    [Theory]
    [InlineData("test1@gmail.com", "Aa123456#", UserType.Examine)]
    [InlineData("test2@gmail.com", "Aa123456!", UserType.QuizAuthor)]
    [InlineData("test3@gmail.com", "Aa123456%", UserType.Examine)]
    public async Task Should_ReturnTokenResponseWithOkStatusCode_WhenUserNameAndPassMatch(string userName,
        string password, UserType userType)
    {
        var createUserCommand =
            new UserRegistrationCommand("test", "one", userName, "144574745", password, password, userType);

        var userCreation = await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Register, createUserCommand);
        userCreation.StatusCode.Should().Be(HttpStatusCode.OK);

        var loginCommand = new LoginCommand(userName, password);

        var loginApiCall = await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Login, loginCommand);

        loginApiCall.StatusCode.Should().Be(HttpStatusCode.OK);
        loginApiCall.Content.Should().NotBeNull();

        var loginResponse = await loginApiCall.Content.ReadFromJsonAsync<LoginResponse>();
        loginResponse.Should().BeOfType<LoginResponse>();
        loginResponse?.Email.Should().Be(userName);
        loginResponse?.Token.Should().NotBeNullOrWhiteSpace();
    }
}
