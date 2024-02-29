using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class QuestionAnswersMark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("QuestionSetId")]
        public virtual QuestionSet QuestionSet { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
