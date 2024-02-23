using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IQuestionOptionsRepository
    {
        Task<IEnumerable<QuestionOption>> GetQuestionOptionsByQuestionIdAsync(int? questionId);

        void CreateQuestionOption();

        void UpdateQuestionOption();

        void DeleteQuestionOption();
    }
}
