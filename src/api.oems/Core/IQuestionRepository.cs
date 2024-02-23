using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(int? questionSetId);

        Task<Question> GetQuestionAsync(int? questionId);

        void CreateQuestion(Question question);

        void UpdateQuestion(Question question);

        void RemoveQuestion(Question question);
    }
}
