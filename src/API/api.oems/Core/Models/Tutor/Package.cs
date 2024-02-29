using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models.Tutor
{
    public class Package: CommonEntity
    {
        public Package()
        {
            this.TutorPackages = new HashSet<TutorInPackage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PackageName { get; set; }

        public decimal PackagePrice { get; set; }

        public int PackageDurationInDays { get; set; }

        public string PackageDescription { get; set; }

        public bool IsShowPrice { get; set; }

        public virtual ICollection<TutorInPackage> TutorPackages { get; set; }
    }
}
