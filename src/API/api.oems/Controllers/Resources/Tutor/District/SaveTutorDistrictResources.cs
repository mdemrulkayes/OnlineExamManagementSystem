using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Tutor.District
{
    public class SaveTutorDistrictResources
    {
        [Required(ErrorMessage = "Please enter District Name")]
        public string DistrictName { get; set; }
    }
}
