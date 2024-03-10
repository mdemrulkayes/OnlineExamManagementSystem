using SharedKernel.Core;

namespace Modules.Question.Core.Tag;
public sealed class Tag : BaseAuditableEntity
{
    public long TagId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    private Tag(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Tag> Create(string name, string? description = default)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return TagErrors.TagNameCanNotBeEmptyValidation;
        }

        if (!string.IsNullOrWhiteSpace(description) && description.Length is <= TagConstants.TagDescriptionMinLength or >= TagConstants.TagDescriptionMaxLength)
        {
            return TagErrors.TagDescriptionValidation;
        }

        return new Tag(name, description);
    }

    public Result<Tag> Update(string name, string? description)
    {
        Name = name;
        Description = description;
        return this;
    }
}
