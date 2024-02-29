using System;
using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.QuestionAnswers
{
    public class SaveQuestionAnswersMarkResources
    {
        [Required(ErrorMessage = "Please select Question Set")]
        public int QuestionSetId { get; set; }

        [Required(ErrorMessage = "Please enter Taken Mark")]
        public float TakenMark { get; set; }

        [Required(ErrorMessage = "Please enter Exam Date & Time")]
        public DateTime ExamDateTime { get; set; }
    }
}
