using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.oems.Controllers.Resources.Tutor.District
{
    public class SaveTutorDistrictResources
    {
        [Required(ErrorMessage = "Please enter District Name")]
        public string DistrictName { get; set; }
    }
}
