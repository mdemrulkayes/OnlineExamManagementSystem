using System;
using api.oems.Core.Models;

namespace api.oems.Controllers.Resources.QuestionAnswers
{
    public class QuestionAnswersResources
    {
        public int Id { get; set; }

        public int QuestionSetId { get; set; }

        public int QuestionId { get; set; }

        public int QuestionOptionId { get; set; }

        public string UserId { get; set; }

        public DateTime ExamDateTime { get; set; }

        public string CorrectAnswer { get; set; }

        public string GivenAnswer { get; set; }

        public int QuestionAnswersMarkId { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public QuestionSet QuestionSet { get; set; }

        public Question Question { get; set; }

        public QuestionOption QuestionOption { get; set; }

        public ApplicationUser User { get; set; }

        public QuestionAnswersMark QuestionAnswersMark { get; set; }

        public ApplicationUser CreatedByUser { get; set; }
    }
}
