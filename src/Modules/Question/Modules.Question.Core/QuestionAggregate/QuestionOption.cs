using SharedKernel.Core;

namespace Modules.Question.Core.QuestionAggregate;
public sealed class QuestionOption : BaseAuditableEntity
{
    public long QuestionOptionId { get; private set; }
    public string OptionText { get; private set; }
    public long QuestionId { get; private set; }
    public bool IsAnswer { get; private set; }

    public Question Question { get; private set; }
}
