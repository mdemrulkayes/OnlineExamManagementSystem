using SharedKernel.Core;

namespace Modules.Question.Core.QuestionAggregate;
public struct QuestionErrors
{
    public static Error QuestionSetNotFound => Error.NotFound("QuestionSet.QuestionSetNotFound", "Question Set not found.");
}
