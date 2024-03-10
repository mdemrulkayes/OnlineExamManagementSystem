using Microsoft.EntityFrameworkCore;
using Modules.Question.Core.QuestionAggregate;
using Modules.Question.Core.Tag;
using Modules.Question.Application.Common;
using QuestionCore = Modules.Question.Core.QuestionAggregate.Question;

namespace Modules.Question.Infrastructure.Data;
internal sealed class QuestionModuleDbContext(DbContextOptions<QuestionModuleDbContext> options) : DbContext(options)
{
    public DbSet<QuestionSet> QuestionSets { get; set; }
    public DbSet<QuestionCore> Questions { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(QuestionModuleConstants.SchemaName);
        builder.ApplyConfigurationsFromAssembly(typeof(QuestionModuleDbContext).Assembly);
    }
}
