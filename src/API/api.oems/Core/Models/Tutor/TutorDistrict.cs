using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models.Tutor
{
    public class TutorDistrict: CommonEntity
    {
        public TutorDistrict()
        {
            this.Areas = new HashSet<TutorArea>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public virtual IEnumerable<TutorArea> Areas { get; set; }
    }
}
