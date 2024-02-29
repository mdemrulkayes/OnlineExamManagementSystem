using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class QuestionOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string OptionE { get; set; }

        public string CorrectAnswer { get; set; }

        public int QuestionId { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public ApplicationUser UpdatedByUser { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Questions { get; set; }
    }
}
