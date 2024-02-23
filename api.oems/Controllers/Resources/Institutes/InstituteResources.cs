using System;
using api.oems.Core.Models;

namespace api.oems.Controllers.Resources.Institutes
{
    public class InstituteResources
    {
        public int Id { get; set; }

        public string InstituteName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsApproved { get; set; }

        public  bool IsRejected { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
