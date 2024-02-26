using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models
{
    public class QuestionSet
    {
        public QuestionSet()
        {
            this.Questions = new HashSet<Question>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string QuestionSetName { get; set; }

        public string QuestionSetCode { get; set; }

        public string Details { get; set; }

        public bool IsEnterprise { get; set; }

        public bool IsGlobal { get; set; }

        public int? SubjectId { get; set; }

        public int QuestionTypeId { get; set; }

        public int? ChapterId { get; set; }

        public float FullMark { get; set; }

        public float? PassedMark { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        
        [ForeignKey("QuestionTypeId")]
        public virtual QuestionType QuestionType { get; set; }

        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual ApplicationUser UpdatedByUser { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
