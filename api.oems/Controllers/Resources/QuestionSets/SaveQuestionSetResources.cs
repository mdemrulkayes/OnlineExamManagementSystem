using System;
using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.QuestionSets
{
    public class SaveQuestionSetResources
    {
        [Required(ErrorMessage = "Please enter Question Set Name")]
        public string QuestionSetName { get; set; }

        [Required(ErrorMessage = "Pleas enter Question Set Code")]
        public string QuestionSetCode { get; set; }

        [Required(ErrorMessage = "Please enter Question Set Details")]
        public string Details { get; set; }

        public bool IsEnterprise { get; set; }

        public bool IsGlobal { get; set; }

        public int? SubjectId { get; set; }

        public int QuestionTypeId { get; set; }

        public int? ChapterId { get; set; }

        public float FullMark { get; set; }

        public float? PassedMark { get; set; }
    }
}
