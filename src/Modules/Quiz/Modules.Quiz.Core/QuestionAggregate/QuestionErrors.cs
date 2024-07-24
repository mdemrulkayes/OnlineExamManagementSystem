using SharedKernel.Core;

namespace Modules.Quiz.Core.QuestionAggregate;
public struct QuestionErrors
{
    public static Error QuestionSetNotFound => Error.NotFound("QuestionSet.QuestionSetNotFound", "Question Set not found.");
}
