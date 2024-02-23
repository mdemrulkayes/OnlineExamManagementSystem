using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models.Tutor
{
    public class ClassInMedium
    {
        public int Id { get; set; }
        public int? MediumId { get; set; }
        public int? ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual TutorClass TutorClass { get; set; }
        [ForeignKey("MediumId")]
        public virtual TutorMedium TutorMedium { get; set; }
    }
}
