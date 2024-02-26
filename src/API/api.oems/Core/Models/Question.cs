using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class Question
    {
        public Question()
        {
            this.QuestionOptions = new HashSet<QuestionOption>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int QuestionSetId { get; set; }

        public string AskedQuestion { get; set; }

        public string QuestionDiscussion { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
       
        [ForeignKey("CreatedBy")]
        public ApplicationUser CreatedByUser { get; set;}

        [ForeignKey("UpdatedBy")]
        public ApplicationUser UpdatedByUser { get; set; }

        [ForeignKey("QuestionSetId")]
        public virtual QuestionSet QuestionSet { get; set; }

        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
