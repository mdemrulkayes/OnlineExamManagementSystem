using Modules.Question.Core.Tag;
using Modules.Question.Infrastructure.Data;
using SharedKernel.Infrastructure;

namespace Modules.Question.Infrastructure.Tag;

internal sealed class TagRepository(QuestionModuleDbContext context)
    : BaseRepository<Core.Tag.Tag>(context), ITagRepository;
