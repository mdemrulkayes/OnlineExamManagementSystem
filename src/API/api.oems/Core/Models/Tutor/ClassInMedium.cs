using System.ComponentModel.DataAnnotations.Schema;

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
