using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.oems.Controllers.Resources.Tutor.District;

namespace api.oems.Controllers.Resources.Tutor.TutorArea
{
    public class TutorAreaResources
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public TutorDistrictResources District { get; set; }
    }
}
