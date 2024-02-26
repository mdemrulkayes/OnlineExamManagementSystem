using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Controllers.Resources.QuestionAnswers
{
    public class SaveQuestionAnswersResources
    {
        [Required(ErrorMessage = "Please select Question Set")]
        public int QuestionSetId { get; set; }

        [Required(ErrorMessage = "Please select Question")]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please select Option")]
        public int QuestionOptionId { get; set; }
        
        [Required(ErrorMessage = "Please select Answer")]
        public string GivenAnswer { get; set; }
    }
}
