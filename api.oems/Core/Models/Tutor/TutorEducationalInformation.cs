using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models.Tutor
{
    public class TutorEducationalInformation: CommonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string UserId { get; set; }

        public int EducationalLevelId { get; set; }

        public string GroupOrSubject { get; set; }

        public string InstituteName { get; set; }

        public int ResultId { get; set; }

        public decimal GradePoint { get; set; }

        public int PassingYear { get; set; }

        public string Achivement { get; set; }

        public string DocumentLocation { get; set; }

        public byte[] DocumentationData { get; set; }

        public string DocumentFormat { get; set; }

        public bool IsDocumentValid { get; set; }

        [ForeignKey("EducationalLevelId")]
        public virtual TutorCommonEntity EducationLevel { get; set; }

        [ForeignKey("ResultId")]
        public virtual TutorCommonEntity Result { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser TutorUser { get; set; }
    }
}
