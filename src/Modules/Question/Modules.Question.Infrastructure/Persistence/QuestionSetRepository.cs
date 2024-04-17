using Modules.Question.Core.QuestionAggregate;
using Modules.Question.Infrastructure.Data;

namespace Modules.Question.Infrastructure.Persistence;
internal sealed class QuestionSetRepository(QuestionModuleDbContext context) : BaseRepository<QuestionSet>(context), IQuestionSetRepository;
