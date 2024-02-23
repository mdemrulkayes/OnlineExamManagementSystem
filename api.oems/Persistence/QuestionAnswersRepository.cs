using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class QuestionAnswersRepository : IQuestionAnswersRepository
    {
        private readonly IRepository<QuestionAnswers> _repository;
        private readonly OemsDbContext _dbContext;

        public QuestionAnswersRepository(OemsDbContext dbContext, IRepository<QuestionAnswers> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionAnswers>> GetAllQuestionAnswersAsync(string userId)
        {
            return await _dbContext.QuestionAnswers
                .Include(x => x.QuestionSet)
                .Include(x => x.Question)
                .Include(x => x.QuestionOption)
                .Include(x => x.User)
                .Include(x => x.QuestionAnswersMark)
                .Include(x => x.CreatedByUser)
                .Where(x => !x.IsDeleted && x.UserId == userId)
                .ToListAsync();
        }

        public async Task<QuestionAnswers> GetQuestionAnswersAsync(int? id, string userId)
        {
            return await _dbContext.QuestionAnswers
                .Include(x => x.QuestionSet)
                .Include(x => x.Question)
                .Include(x => x.QuestionOption)
                .Include(x => x.User)
                .Include(x => x.QuestionAnswersMark)
                .Include(x => x.CreatedByUser)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted && x.UserId == userId);
        }

        public void CreateQuestionAnswers(QuestionAnswers questionAnswers)
        {
            _repository.Create(questionAnswers);
        }
    }
}
