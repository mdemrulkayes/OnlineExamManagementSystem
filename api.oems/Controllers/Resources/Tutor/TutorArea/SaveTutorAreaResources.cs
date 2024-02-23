using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Controllers.Resources.Tutor.TutorArea
{
    public class SaveTutorAreaResources
    {
        [Required(ErrorMessage = "Please enter Area Name")]
        public string AreaName { get; set; }
        public int? DistrictId { get; set; }
    }
}
