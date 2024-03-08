using Quizzer.Api.FunctionalTest.Abstraction;

namespace Quizzer.Api.FunctionalTest.Modules.Identity.Features.Profile;

public sealed class ProfileEndpointTest(QuizzerWebApiFactory factory) : QuizzerBaseFunctionTest(factory)
{
    [Fact]
    public async Task Should_ReturnLoggedInUserDetails_WhenUserHasValidToken()
    {

    }
}
