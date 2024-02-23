using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models.Tutor
{
    public class TutorPersonalInformation: CommonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long UserReferenceId { get; set; }

        public string UserId { get; set; }

        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public bool IsEmailVarified { get; set; }

        public bool IsMobilePhoneVarified { get; set; }

        public int BloodGroup { get; set; }

        public int MaritialStatus { get; set; }

        public string Experience { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string Nationality { get; set; }

        public string Religion { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser TutorUser { get; set; }
    }
}
