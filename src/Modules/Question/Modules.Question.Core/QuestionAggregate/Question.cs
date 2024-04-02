using System.Collections.ObjectModel;
using SharedKernel.Core;

namespace Modules.Question.Core.QuestionAggregate;
public sealed class Question : BaseAuditableEntity
{
    public long QuestionId { get; private set; }
    public string AskedQuestion { get; private set; }
    public string Discussion { get; private set; }

    public int QuestionMark { get; private set; }

    public long QuestionSetId { get; private set; }
    public QuestionSet QuestionSet { get; private set; }

    public IReadOnlyCollection<QuestionOption> Options => new ReadOnlyCollection<QuestionOption>(QuestionOptions);

    internal List<QuestionOption> QuestionOptions = [];
}
