using System;
using System.Collections.Generic;
using api.oems.Core.Models.Tutor;
using Microsoft.AspNetCore.Identity;

namespace api.oems.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Institutes = new HashSet<UserWithInstitute>();
            this.TutorPackages = new HashSet<TutorInPackage>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<UserWithInstitute> Institutes { get; set; }

        public virtual ICollection<TutorInPackage> TutorPackages { get; set; }
    }
}
