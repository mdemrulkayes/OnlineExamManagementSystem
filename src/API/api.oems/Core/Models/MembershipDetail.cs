using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.oems.Core.Models
{
    public class MembershipDetail
    {
        [Key]
        public int Id { get; set; }

        public string MembershipName { get; set; }

        public int CurrencyId { get; set; }

        public decimal MembershipPrice { get; set; }

        public int MembershipDuration { get; set; }

        public bool IsFree { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
