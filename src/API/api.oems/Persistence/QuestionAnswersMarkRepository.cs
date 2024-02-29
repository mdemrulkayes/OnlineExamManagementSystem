using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class QuestionAnswersMarkRepository : IQuestionAnswersMarkRepository
    {
        private readonly IRepository<QuestionAnswersMark> _repository;
        private readonly OemsDbContext _dbContext;

        public QuestionAnswersMarkRepository(OemsDbContext dbContext, IRepository<QuestionAnswersMark> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionAnswersMark>> GetAllQuestionAnswersMarkAsync(string userId)
        {
            return await _dbContext.QuestionAnswersMark
                .Include(x => x.QuestionSet)
                .Include(x => x.User)
                .Include(x => x.CreatedByUser)
                .Where(x => !x.IsDeleted && x.UserId == userId)
                .ToListAsync();
        }

        public async Task<QuestionAnswersMark> GetQuestionAnswersMarkAsync(int? id, string userId)
        {
            return await _dbContext.QuestionAnswersMark
                .Include(x => x.QuestionSet)
                .Include(x => x.User)
                .Include(x => x.CreatedByUser)
                .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id && x.UserId == userId);
        }

        public void CreateQuestionAnswersMark(QuestionAnswersMark questionAnswersMark)
        {
            _repository.Create(questionAnswersMark);
        }
    }
}
