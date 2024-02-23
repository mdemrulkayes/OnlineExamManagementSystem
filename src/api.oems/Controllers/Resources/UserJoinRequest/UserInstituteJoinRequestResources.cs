using System;
using api.oems.Core.Models;

namespace api.oems.Controllers.Resources.UserJoinRequest
{
    public class UserInstituteJoinRequestResources
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int InstituteId { get; set; }

        public bool IsRequestApproved { get; set; }

        public bool IsRequestCanceled { get; set; }

        public bool IsInstituteLeft { get; set; }

        public DateTime JoinRequestAt { get; set; }

        public string ApprovedBy { get; set; }

        public virtual ApplicationUser StudentUser { get; set; }

        public virtual ApplicationUser ApprovedByUser { get; set; }

        public virtual Institute Institute { get; set; }
    }
}
