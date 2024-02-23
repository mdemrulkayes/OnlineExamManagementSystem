using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models.Tutor
{
    public class TutorRequest: CommonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DistrictId { get; set; }

        public int AreaId { get; set; }

        public int MediumId { get; set; }

        public int ClassId { get; set; }

        public int SubjectId { get; set; }

        public string StudentInstituteName { get; set; }

        public int DaysPerWeekId { get; set; }

        public int StudentGender { get; set; }

        public int SalaryRangeId { get; set; }

        public int TutorGender { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public string AdditionalInformation { get; set; }

        public DateTime? ValidateTo { get; set; }

        [ForeignKey("DistrictId")]
        public virtual TutorDistrict District { get; set; }

        [ForeignKey("AreaId")]
        public virtual TutorArea Area { get; set; }

        [ForeignKey("MediumId")]
        public virtual TutorMedium Medium { get; set; }

        [ForeignKey("ClassId")]
        public virtual TutorClass Class { get; set; }

        [ForeignKey("SubjectId")]
        public virtual TutorSubject Subject { get; set; }

        [ForeignKey("SalaryRangeId")]
        public virtual TutorCommonEntity SalaryRange { get; set; }

        [ForeignKey("DaysPerWeekId")]
        public virtual TutorCommonEntity DaysPerWeek { get; set; }
    }
}
