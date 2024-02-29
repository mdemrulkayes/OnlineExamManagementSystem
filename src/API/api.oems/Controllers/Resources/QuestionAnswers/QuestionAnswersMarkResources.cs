using System;
using api.oems.Core.Models;

namespace api.oems.Controllers.Resources.QuestionAnswers
{
    public class QuestionAnswersMarkResources
    {
        public int Id { get; set; }

        public int QuestionSetId { get; set; }

        public string UserId { get; set; }

        public float FullMark { get; set; }

        public float? PassedMark { get; set; }

        public float TakenMark { get; set; }

        public DateTime ExamDateTime { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public QuestionSet QuestionSet { get; set; }

        public ApplicationUser User { get; set; }

        public ApplicationUser CreatedByUser { get; set; }
    }
}
