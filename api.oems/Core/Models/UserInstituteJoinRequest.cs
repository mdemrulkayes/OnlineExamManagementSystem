using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Core.Models
{
    public class UserInstituteJoinRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int InstituteId { get; set; }

        public bool IsRequestApproved { get; set; }

        public bool IsRequestCanceled { get; set; }

        public bool IsInstituteLeft { get; set; }

        public bool IsRequestRejected { get; set; }

        public DateTime JoinRequestAt { get; set; }

        public string ApprovedBy { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser StudentUser { get; set; }

        [ForeignKey("ApprovedBy")]
        public virtual ApplicationUser ApprovedByUser { get; set; }

        [ForeignKey("InstituteId")]
        public virtual Institute Institute { get; set; }
    }
}
