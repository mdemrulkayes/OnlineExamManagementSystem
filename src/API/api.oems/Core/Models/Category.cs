using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class Category
    {
        public Category()
        {
            this.Institutes = new HashSet<CategoriesInInstitute>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedUser { get; set; }

        public virtual ICollection<CategoriesInInstitute> Institutes { get; set; }
    }
}
