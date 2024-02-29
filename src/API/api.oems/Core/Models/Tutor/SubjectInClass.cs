using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models.Tutor
{
    public class SubjectInClass
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }

        [ForeignKey("ClassId")]
        public virtual TutorClass TutorClass { get; set; }
        [ForeignKey("SubjectId")]
        public virtual TutorSubject TutorSubject { get; set; }
    }
}
