using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models.Tutor
{
    public class TutorInPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PackageId { get; set; }

        public DateTime ActivationStartDate { get; set; }

        public DateTime ActivationEndDate { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser TutorUser { get; set; }

        [ForeignKey("PackageId")]
        public virtual Package TutorPackage { get; set; }
    }
}
