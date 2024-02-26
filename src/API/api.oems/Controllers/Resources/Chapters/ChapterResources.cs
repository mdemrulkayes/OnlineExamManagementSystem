using System;
using api.oems.Core.Models;

namespace api.oems.Controllers.Resources.Chapters
{
    public class ChapterResources
    {
        public int Id { get; set; }

        public string ChapterName { get; set; }

        public string ChapterCode { get; set; }

        public bool IsDeleted { get; set; }

        public int SubjectId { get; set; }

        public string ChapterDetails { get; set; }

        public virtual Subject Subject { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
