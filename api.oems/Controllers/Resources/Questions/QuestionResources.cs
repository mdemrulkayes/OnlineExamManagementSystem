using System.Collections.Generic;
using api.oems.Controllers.Resources.QuestionOptions;

namespace api.oems.Controllers.Resources.Questions
{
    public class QuestionResources
    {
        public QuestionResources()
        {
            this.QuestionOptions = new HashSet<QuestionOptionResources>();
        }

        public int Id { get; set; }

        public int QuestionSetId { get; set; }

        public string AskedQuestion { get; set; }

        public string QuestionDiscussion { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<QuestionOptionResources> QuestionOptions { get; set; }
    }
}
