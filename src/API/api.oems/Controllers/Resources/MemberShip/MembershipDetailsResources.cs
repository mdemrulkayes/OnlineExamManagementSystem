using System;

namespace api.oems.Controllers.Resources.MemberShip
{
    public class MembershipDetailsResources
    {
        public int Id { get; set; }

        public string MembershipName { get; set; }

        public int CurrencyId { get; set; }

        public decimal MembershipPrice { get; set; }

        public int MembershipDuration { get; set; }

        public bool IsFree { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
