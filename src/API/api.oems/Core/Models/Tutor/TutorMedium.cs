using System.Collections.Generic;

namespace api.oems.Core.Models.Tutor
{
    public class TutorMedium: CommonEntity
    {
        public TutorMedium()
        {
            this.ClassInMediums = new HashSet<ClassInMedium>();
        }

        public int Id { get; set; }
        public string MediumName { get; set; }

        public virtual ICollection<ClassInMedium> ClassInMediums { get; set; }
    }
}
