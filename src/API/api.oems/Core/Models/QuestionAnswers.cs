using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class QuestionAnswers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? QuestionSetId { get; set; }

        [Required]
        public int? QuestionId { get; set; }

        [Required]
        public int? QuestionOptionId { get; set; }

        public string UserId { get; set; }

        public DateTime ExamDateTime { get; set; }

        public string CorrectAnswer { get; set; }

        public string GivenAnswer { get; set; }

        public int QuestionAnswersMarkId { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey("QuestionSetId")]
        public virtual QuestionSet QuestionSet { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("QuestionAnswersMarkId")]
        public virtual QuestionAnswersMark QuestionAnswersMark { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
