using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace api.oems.Persistence
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IRepository<Question> _repository;
        private readonly OemsDbContext _context;

        public QuestionRepository(IRepository<Question> repository, OemsDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(int? questionSetId)
        {
            return await _context.Questions
                .Include(x => x.QuestionSet)
                .Include(x => x.QuestionOptions)
                .Where(x => x.QuestionSetId == questionSetId).ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int? questionId)
        {
            return await _context.Questions
                .Include(x => x.QuestionSet)
                .Include(x => x.QuestionOptions)
                .FirstOrDefaultAsync(x => x.Id == questionId);
        }

        public void CreateQuestion(Question question)
        {
            _repository.Create(question);
        }

        public void UpdateQuestion(Question question)
        {
            _repository.Update(question);
        }

        public void RemoveQuestion(Question question)
        {
            _repository.Delete(question);
        }
    }
}
