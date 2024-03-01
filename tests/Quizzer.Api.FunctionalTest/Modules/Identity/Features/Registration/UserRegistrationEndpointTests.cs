using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Identity.Constants;
using Modules.Identity.Features.Registration;
using Modules.Identity.Features.Registration.Enums;
using Newtonsoft.Json;
using Quizzer.Api.FunctionalTest.Abstraction;
using SharedKernel.Core;

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

    [Fact]
    public async Task Should_ReturnValidationError_WhenFirstNameIsNotSupplied()
    {
        //Arrange

        var registerUserCommand = new UserRegistrationCommand("", "User", "test.user130@gmail.com", "015478455", "123456@Qa",
            "123456@Qa", UserType.QuizAuthor);

        //Act

        HttpResponseMessage response =
            await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Register, registerUserCommand);

        //Assert

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var responseContent = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        responseContent.Should().NotBeNull();
        var errors = JsonConvert.DeserializeObject<List<Error>>(responseContent?.Extensions["errors"]?.ToString() ?? string.Empty);
        errors?.FirstOrDefault()?.Message.Should().Be("First name can not be empty");
    }

    [Theory]
    [InlineData(UserType.SuperAdmin)]
    [InlineData(UserType.SupportAdmin)]
    public async Task Should_ReturnValidationResultObject_WhenUserTypeIsSuperAdminOrSupportAdmin(UserType userType)
    {
        //Arrange

        var registerUserCommand = new UserRegistrationCommand("Test", "User", "test.user129@gmail.com", "015478455", "123456@Qa",
            "123456@Qa", userType);

        //Act

        HttpResponseMessage response =
            await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Register, registerUserCommand);

        //Assert

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        var responseContent = await response.Content.ReadFromJsonAsync<ProblemDetails>();
        responseContent.Should().NotBeNull();

        responseContent?.Status.Should().Be(StatusCodes.Status400BadRequest);
        responseContent?.Title.Should().Be("Identity.Registration");
        responseContent?.Detail.Should().Be("Selected User type is not valid to use this registration flow");
    }

    [Fact]
    public async Task Should_AddCreatedDate_WhenUserRegisteredSuccessfully()
    {
        //Arrange

        var registerUserCommand = new UserRegistrationCommand("Test", "User", "test.user127@gmail.com", "015478455", "123456@Qa",
            "123456@Qa", UserType.QuizAuthor);

        //Act

        HttpResponseMessage response =
            await HttpClient.PostAsJsonAsync(IdentityModuleConstants.Route.Register, registerUserCommand);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var userDetails = await UserManager.FindByEmailAsync(registerUserCommand.Email);
        userDetails.Should().NotBeNull();

        userDetails?.CreatedDate.Date.Should().Be(DateTime.Today);
    }
}
