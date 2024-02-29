using System.Collections.Generic;

namespace api.oems.Core.Models.Tutor
{
    public class TutorSubject: CommonEntity
    {
        public TutorSubject()
        {
            this.SubjectInClasses = new HashSet<SubjectInClass>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<SubjectInClass> SubjectInClasses { get; set; }
    }
}
