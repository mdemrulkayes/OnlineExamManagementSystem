using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core;
using api.oems.Core.Models;

namespace api.oems.Persistence
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly IRepository<QuestionType> _repository;

        public QuestionTypeRepository(IRepository<QuestionType> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionType>> GetAllQuestionTypesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
