using System.Collections.ObjectModel;
using SharedKernel.Core;

namespace Modules.Question.Core.QuestionAggregate;
public sealed class QuestionSet : BaseAuditableEntity, IAggregateRoot
{
    public long QuestionSetId { get; private set; }
    public string Name { get; private set; }
    public string? SetCode { get; private set; }
    public string? Details { get; private set; }

    public IReadOnlyCollection<QuestionSetTag> Tags => new ReadOnlyCollection<QuestionSetTag>(QuestionSetTags);

    internal List<QuestionSetTag> QuestionSetTags = [];
}
