using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.oems.Controllers.Resources.QuestionOptions;

namespace api.oems.Controllers.Resources.Questions
{
    public class SaveQuestionResources
    {
        [Required(ErrorMessage = "Please select Question Set")]
        public int QuestionSetId { get; set; }

        [Required(ErrorMessage = "Please enter Question")]
        public string AskedQuestion { get; set; }

        public string QuestionDiscussion { get; set; }

        public ICollection<SaveQuestionOptionResources> QuestionOptions { get; set; }
    }
}
