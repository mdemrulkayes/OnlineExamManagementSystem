using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IQuestionAnswersRepository
    {
        Task<IEnumerable<QuestionAnswers>> GetAllQuestionAnswersAsync(string userId);

        Task<QuestionAnswers> GetQuestionAnswersAsync(int? id, string userId);

        void CreateQuestionAnswers(QuestionAnswers questionAnswers);
    }
}
