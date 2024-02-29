using System.ComponentModel.DataAnnotations;

namespace api.oems.Controllers.Resources.Institutes
{
    public class SaveInstituteResources
    {
        [Required(ErrorMessage = "Please enter Institute Name")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Location")]
        public string Location { get; set; }
    }
}
