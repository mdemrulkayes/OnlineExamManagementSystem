using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Controllers.Resources.MemberShip
{
    public class SaveMembershipDetailsResources
    {
        [Required(ErrorMessage = "Please enter Membership Name")]
        public string MembershipName { get; set; }

        [Required(ErrorMessage = "Please enter Currency")]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Please enter Membership Price")]
        public decimal MembershipPrice { get; set; }

        [Required(ErrorMessage = "Please enter Membership Duration in Month")]
        public int MembershipDuration { get; set; }

        public bool IsFree { get; set; }

        public string CreatedBy { get; set; }
    }
}
