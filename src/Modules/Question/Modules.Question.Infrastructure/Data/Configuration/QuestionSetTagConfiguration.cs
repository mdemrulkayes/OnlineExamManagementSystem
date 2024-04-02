using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Question.Core.QuestionAggregate;

namespace Modules.Question.Infrastructure.Data.Configuration;
internal sealed class QuestionSetTagConfiguration : IEntityTypeConfiguration<QuestionSetTag>
{
    public void Configure(EntityTypeBuilder<QuestionSetTag> builder)
    {
        builder
            .HasKey(x => new { x.QuestionSetId, x.TagId });

        builder.HasOne(x => x.QuestionSet)
            .WithMany(x => x.QuestionSetTags)
            .HasForeignKey(x => x.QuestionSetId);

        builder.HasOne(x => x.Tag)
            .WithMany(x => x.QuestionSetTags)
            .HasForeignKey(x => x.TagId);
    }
}
