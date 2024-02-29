using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;

namespace api.oems.Persistence
{
    public class QuestionOptionsRepository : IQuestionOptionsRepository
    {
        private readonly IRepository<QuestionOption> _repository;
        private readonly OemsDbContext _dbContext;

        public QuestionOptionsRepository(IRepository<QuestionOption> repository, OemsDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<QuestionOption>> GetQuestionOptionsByQuestionIdAsync(int? questionId)
        {
            return await _repository.GetAllAsync(x => x.QuestionId == questionId);
        }

        public void CreateQuestionOption()
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestionOption()
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestionOption()
        {
            throw new NotImplementedException();
        }
    }
}
