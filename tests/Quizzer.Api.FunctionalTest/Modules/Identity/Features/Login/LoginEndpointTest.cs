using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Modules.Identity.Constants;
using Modules.Identity.Features.Login;
using Quizzer.Api.FunctionalTest.Abstraction;

namespace Quizzer.Api.FunctionalTest.Modules.Identity.Features.Login;

public class LoginEndpointTest : QuizzerBaseFunctionTest
{
    public LoginEndpointTest(QuizzerWebApiFactory factory) : base(factory)
    {
        RegisterOneTimeUser().Wait();
    }
    [Theory]
    [ClassData(typeof(UserDataCollection))]
    public async Task Should_ReturnTokenResponseWithOkStatusCode_WhenUserNameAndPassMatch(string userName,
        string password)
    {
        var loginApiCall = await LoginApiCall(userName, password);

        loginApiCall.StatusCode.Should().Be(HttpStatusCode.OK);
        loginApiCall.Content.Should().NotBeNull();

        var loginResponse = await loginApiCall.Content.ReadFromJsonAsync<LoginResponse>();
        loginResponse.Should().BeOfType<LoginResponse>();
        loginResponse?.Email.Should().Be(userName);
        loginResponse?.Token.Should().NotBeNullOrWhiteSpace();
    }

    private async Task<HttpResponseMessage> LoginApiCall(string userName, string password)
    {
        var loginCommand = new LoginCommand(userName, password);

        var loginApiCall = await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Login, loginCommand);
        return loginApiCall;
    }

    [Theory]
    [ClassData(typeof(UserDataCollection))]
    public async Task Should_AddLastLoginTime_AfterSuccessfulLogin(string userName, string password)
    {
        var loginApiCall = await LoginApiCall(userName, password);

        loginApiCall.StatusCode.Should().Be(HttpStatusCode.OK);
        loginApiCall.Content.Should().NotBeNull();

        var userDetails = await UserManager.FindByEmailAsync(userName);
        userDetails.Should().NotBeNull();
        userDetails?.LastLoginTime.Should().NotBeNull();
        userDetails?.LastLoginTime.Should().BeSameDateAs(DateTimeOffset.UtcNow);
        userDetails?.UpdatedDate.Should().NotBeNull("After updating user last login time, the UpdateDate column should also be updated");
    }
}
