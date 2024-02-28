using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Modules.Identity.Constants;
using Modules.Identity.Features.Registration;
using Modules.Identity.Features.Registration.Enums;
using Quizzer.Api.FunctionalTest.Abstraction;

namespace Quizzer.Api.FunctionalTest.Modules.Identity.Features.Registration;
public class UserRegistrationEndpointTests(QuizzerWebApiFactory factory) : QuizzerBaseFunctionTest(factory)
{
    [Fact]
    public async Task Should_CreateUserSuccessfully_WhenRegisterRequestIsValid()
    {
        //Arrange

        var registerUserCommand = new UserRegistrationCommand("Test", "User", "test.user123@gmail.com", "015478455", "123456@Qa",
            "123456@Qa", UserType.QuizAuthor);

        //Act

        HttpResponseMessage response =
            await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Register, registerUserCommand);

        //Assert

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var responseContent = await response.Content.ReadAsStringAsync();
        responseContent.Should().BeNullOrEmpty();
    }
}
