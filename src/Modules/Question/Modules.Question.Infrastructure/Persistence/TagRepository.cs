using Modules.Question.Core.Tag;
using Modules.Question.Infrastructure.Data;

namespace Modules.Question.Infrastructure.Persistence;

internal sealed class TagRepository(QuestionModuleDbContext context)
    : BaseRepository<Tag>(context), ITagRepository;
