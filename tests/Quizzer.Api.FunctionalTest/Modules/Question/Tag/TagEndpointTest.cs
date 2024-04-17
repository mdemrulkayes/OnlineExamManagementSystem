using Quizzer.Api.FunctionalTest.Abstraction;

namespace Quizzer.Api.FunctionalTest.Modules.Question.Tag;
public sealed class TagEndpointTest : QuizzerBaseFunctionTest
{
    public TagEndpointTest(QuizzerWebApiFactory factory) : base(factory)
    {
        RegisterOneTimeUser().Wait();
        LoginOneTimeUser().Wait();
    }
}
