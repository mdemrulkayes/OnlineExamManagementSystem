using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models.Tutor
{
    public class TutorClass : CommonEntity
    {
        public TutorClass()
        {
            this.ClassInMediums = new HashSet<ClassInMedium>();
            this.SubjectInClasses = new HashSet<SubjectInClass>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<ClassInMedium> ClassInMediums { get; set; }
        public virtual ICollection<SubjectInClass> SubjectInClasses { get; set; }
    }
}
