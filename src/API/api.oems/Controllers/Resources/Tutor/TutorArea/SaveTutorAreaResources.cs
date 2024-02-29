using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Tutor.TutorArea
{
    public class SaveTutorAreaResources
    {
        [Required(ErrorMessage = "Please enter Area Name")]
        public string AreaName { get; set; }
        public int? DistrictId { get; set; }
    }
}
