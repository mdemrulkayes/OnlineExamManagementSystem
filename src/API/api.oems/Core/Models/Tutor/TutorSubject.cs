using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
