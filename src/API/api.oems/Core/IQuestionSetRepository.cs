using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IQuestionSetRepository
    {
        Task<IEnumerable<QuestionSet>> GetAllQuestionSetsAsync(string userId);

        Task<QuestionSet> GetQuestionSetAsync(int? id, string userId);

        void CreateQuestionSet(QuestionSet questionSet);

        void UpdateQuestionSet(QuestionSet questionSet);

        void DeleteQuestionSet(QuestionSet questionSet);
    }
}
