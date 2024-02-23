using System;
using System.Collections.Generic;
using api.oems.Core.Models;

namespace api.oems.Controllers.Resources.QuestionSets
{
    public class QuestionSetResources
    {
        public QuestionSetResources()
        {
            this.Questions = new HashSet<Question>();
        }

        public int Id { get; set; }

        public string QuestionSetName { get; set; }

        public string QuestionSetCode { get; set; }

        public string Details { get; set; }

        public bool IsEnterprise { get; set; }

        public bool IsGlobal { get; set; }

        public int? SubjectId { get; set; }

        public int QuestionTypeId { get; set; }

        public int? ChapterId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool Isdeleted { get; set; }

        public float FullMark { get; set; }

        public float? PassedMark { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual QuestionType QuestionType { get; set; }

        public virtual Chapter Chapter { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ApplicationUser UpdatedByUser { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
