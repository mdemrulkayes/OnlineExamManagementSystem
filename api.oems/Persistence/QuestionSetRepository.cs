using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class QuestionSetRepository : IQuestionSetRepository
    {
        private readonly IRepository<QuestionSet> _repository;
        private readonly OemsDbContext _dbContext;


        public QuestionSetRepository(OemsDbContext dbContext, IRepository<QuestionSet> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionSet>> GetAllQuestionSetsAsync(string userId)
        {
            return await _dbContext.QuestionSets
                .Include(x => x.Subject)
                .Include(x => x.Chapter)
                .Include(x => x.QuestionType)
                .Include(x => x.Questions)
                .Where(x => !x.IsDeleted &&  (x.Subject.Category.Institutes.Any(y => y.Institute.UserId == userId) 
                            || 
                            x.Chapter.Subject.Category.Institutes.Any(y => y.Institute.UserId == userId)))      
                .ToListAsync();
        }

        public async Task<QuestionSet> GetQuestionSetAsync(int? id,string userId)
        {
            return await _dbContext.QuestionSets
                .Include(x => x.Subject)
                .Include(x => x.Chapter)
                .Include(x => x.QuestionType)
                .Include(x => x.Questions)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted && (x.Subject.Category.Institutes.Any(y => y.Institute.UserId == userId)
                            ||
                            x.Chapter.Subject.Category.Institutes.Any(y => y.Institute.UserId == userId)));
        }

        public void CreateQuestionSet(QuestionSet questionSet)
        {
            _repository.Create(questionSet);
        }

        public void UpdateQuestionSet(QuestionSet questionSet)
        {
            _repository.Update(questionSet);
        }

        public void DeleteQuestionSet(QuestionSet questionSet)
        {
            _repository.Delete(questionSet);
        }
    }
}
