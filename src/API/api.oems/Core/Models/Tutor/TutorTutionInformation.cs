using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models.Tutor
{
    public class TutorTutionInformation: CommonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string HigherEducationalDegreeName { get; set; }

        public string HigherEducationalInstitute { get; set; }

        public decimal ExpectedSalary { get; set; }

        public bool IsSalaryNegotiable { get; set; }

        public bool IsGroupTution { get; set; }

        public bool IsPrivateTution { get; set; }

        public bool IsTutionInClassRoom { get; set; }

        public bool IsTutionInCoachingCenter { get; set; }

        public bool IsTutionInHomeVisit { get; set; }

        public bool IsInTutorPlace { get; set; }

        public bool IsProvideOnlineHelp { get; set; }

        public bool IsProvidePhoneHelp { get; set; }

        public bool IsProvideHandNotes { get; set; }

        public bool IsProvideVideoTutorials { get; set; }

        public int DaysPerWeekId { get; set; }

        public int PreferredDistrictId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser TutorUser { get; set; }  

        [ForeignKey("PreferredDistrictId")]
        public virtual TutorDistrict District { get; set; }

        [ForeignKey("DaysPerWeekId")]
        public virtual TutorCommonEntity DaysPerWeek { get; set; }
    }
}
