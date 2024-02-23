using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        public string ChapterName { get; set; }

        public string ChapterCode { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public string ChapterDetails { get; set; }

        public virtual Subject Subject { get; set; }

        [ForeignKey("ApplicationUser")]
        public string CreatedBy { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
