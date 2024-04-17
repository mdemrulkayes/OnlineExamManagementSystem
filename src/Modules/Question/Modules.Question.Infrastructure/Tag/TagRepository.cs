using Modules.Question.Core.Tag;
using Modules.Question.Infrastructure.Data;
using Modules.Question.Infrastructure.Persistence;

namespace Modules.Question.Infrastructure.Tag;

internal sealed class TagRepository(QuestionModuleDbContext context)
    : BaseRepository<Core.Tag.Tag>(context), ITagRepository;
