using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public string SubjectCode { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CreatedByUser")]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("UpdatedByUser")]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }

        public virtual ApplicationUser UpdatedByUser { get; set; }

        public virtual Category Category { get; set; }

    }
}
