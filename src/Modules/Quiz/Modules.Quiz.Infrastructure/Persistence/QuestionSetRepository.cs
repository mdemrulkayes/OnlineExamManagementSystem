using Modules.Quiz.Core.QuestionAggregate;
using Modules.Quiz.Infrastructure.Data;

namespace Modules.Quiz.Infrastructure.Persistence;
internal sealed class QuestionSetRepository(QuestionModuleDbContext context) : BaseRepository<QuestionSet>(context), IQuestionSetRepository;
