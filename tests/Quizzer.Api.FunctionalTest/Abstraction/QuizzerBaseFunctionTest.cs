namespace Quizzer.Api.FunctionalTest.Abstraction;
public class QuizzerBaseFunctionTest(QuizzerWebApiFactory factory) 
    : IClassFixture<QuizzerWebApiFactory>
{
    protected HttpClient HttpClient = factory.CreateClient();
}
