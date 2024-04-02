using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Question.Core.QuestionAggregate;

namespace Modules.Question.Infrastructure.Data.Configuration;
internal sealed class QuestionSetConfiguration : IEntityTypeConfiguration<QuestionSet>
{
    public void Configure(EntityTypeBuilder<QuestionSet> builder)
    {
        builder
            .Property(x => x.QuestionSetId)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
