using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class Institute
    {
        public Institute()
        {
            this.Categories = new HashSet<CategoriesInInstitute>();
            this.Students = new HashSet<UserWithInstitute>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string InstituteName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<CategoriesInInstitute> Categories { get; set; }

        public virtual ICollection<UserWithInstitute> Students { get; set; }
    }
}
