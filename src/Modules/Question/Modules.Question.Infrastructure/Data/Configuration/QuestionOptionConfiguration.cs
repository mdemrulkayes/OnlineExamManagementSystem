using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Question.Core.QuestionAggregate;

namespace Modules.Question.Infrastructure.Data.Configuration;
internal sealed class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.Property(x => x.QuestionId)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.OptionText)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasQueryFilter(x => x.DeletedDate == null);
    }
}
