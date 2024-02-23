using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IQuestionAnswersMarkRepository
    {
        Task<IEnumerable<QuestionAnswersMark>> GetAllQuestionAnswersMarkAsync(string userId);

        Task<QuestionAnswersMark> GetQuestionAnswersMarkAsync(int? id, string userId);

        void CreateQuestionAnswersMark(QuestionAnswersMark questionAnswersMark);
    }
}
