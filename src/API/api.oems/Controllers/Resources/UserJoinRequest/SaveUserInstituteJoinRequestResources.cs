using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.UserJoinRequest
{
    public class SaveUserInstituteJoinRequestResources
    {
        [Required(ErrorMessage = "Please Select Instrument")]
        public int InstituteId { get; set; }
    }
}
