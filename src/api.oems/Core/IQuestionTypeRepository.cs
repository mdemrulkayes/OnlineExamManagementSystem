using System.Collections.Generic;
using System.Threading.Tasks;
using api.oems.Core.Models;

namespace api.oems.Core
{
    public interface IQuestionTypeRepository
    {
        Task<IEnumerable<QuestionType>> GetAllQuestionTypesAsync();
    }
}
