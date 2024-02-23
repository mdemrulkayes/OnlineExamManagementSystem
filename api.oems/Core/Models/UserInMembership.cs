using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models
{
    public class UserInMembership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int MembershipId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string ConfirmedBy { get; set; }

        public DateTime? ConfirmedAt { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser MembershipedUser { get; set; }

        [ForeignKey("MembershipId")]
        public MembershipDetail MembershipDetails { get; set; }

        [ForeignKey("ConfirmedBy")]
        public ApplicationUser ConfirmedUser { get; set; }

    }
}
