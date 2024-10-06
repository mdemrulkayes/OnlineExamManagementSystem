using Modules.Quiz.Core.QuestionAggregate;
using Modules.Quiz.Infrastructure.Data;

namespace Modules.Quiz.Infrastructure.Persistence;
internal sealed class QuestionRepository(QuestionModuleDbContext context) : BaseRepository<Core.QuestionAggregate.Question>(context), IQuestionRepository;
